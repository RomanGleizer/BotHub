<template>
  <div class="search-container">
    <input v-model="search" class="search" placeholder="введите название бота или краткую информацию" type="text">
  </div>
<div class="line"></div>
  <div class="swiper">
    <swiper
        :modules="modules"
        :slides-per-view="1"
        :space-between="500"
        :loop="true"
        navigation
        :pagination="{ clickable: true }"
    >
      <swiper-slide class="bot-card" v-for="bot in adsList" :key="bot.id">
        <AdsElement :bot="bot"></AdsElement>
      </swiper-slide>
    </swiper>
  </div>
  <div class="filter">
    <button @click="sortParam='popular'" class="filter-button" :class="{'filter-active': isPopular}" >Популярное</button>
    <button @click="sortParam='new'" class="filter-button" :class="{'filter-active': isNew}">Новинки</button>
    <button @click="sortParam='comments'" class="filter-button" :class="{'filter-active': isCommented}">Обсуждаемое</button>
  </div>
  <div class="bot-list">
    <div class="bot-card" v-for="bot in searchList" :key="bot.id">
      <BotCardElement :bot="bot"></BotCardElement>
    </div>
<!--    <button @click="console.log(botList)">Список ботов</button>-->
  </div>
</template>

<script>
import { Navigation, Pagination, Scrollbar, A11y } from 'swiper/modules';
  import { Swiper, SwiperSlide } from 'swiper/vue';
  import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';
import 'swiper/css/scrollbar';

import AdsElement from "@/components/elements/Ads-Element.vue";
import BotCardElement from "@/components/elements/Bot-Card-Element.vue";
import BotList from "@/botList.json";
import AdsList from "@/adsList.json"

  export default {
    data() {
      return {
        botList: BotList,
        adsList: AdsList,
        sortParam: '',
        isPopular: true,
        isNew: false,
        isCommented: false,
        search: "",
      }
    },
    components: {
      AdsElement,
      BotCardElement,
      Swiper,
      SwiperSlide,
    },
    setup() {
      return {
        modules: [Navigation, Pagination, Scrollbar, A11y],
      };
    },
    computed: {
      sortedList() {
        switch (this.sortParam) {
          case 'popular':
            return this.botList.slice().sort(this.sortByPopular);
          case 'new':
            return this.botList.slice().sort(this.sortByNew);
          case 'comments':
            return this.botList.slice().sort(this.sortByComments);
          default:
            return this.botList.slice().sort(this.sortByPopular);
        }
      },
      searchList() {
        return this.sortedList.filter(bot => {
          return bot.name.toLowerCase().includes(this.search.toLowerCase()) || bot.miniDescription.toLowerCase().includes(this.search.toLowerCase())
        })
      }
    },
    methods: {
      sortByPopular(d1, d2) {
        this.isPopular = true;
        this.isCommented = false;
        this.isNew = false;
        return (d1.likes-d1.dislikes < d2.likes-d2.dislikes) ? 1 : -1;
      },
      sortByNew(d1, d2) {
        this.isPopular = false;
        this.isCommented = false;
        this.isNew = true;
        return (new Date(d1.date) > new Date(d2.date)) ? 1 : -1;
      },
      sortByComments(d1, d2) {
        this.isPopular = false;
        this.isCommented = true;
        this.isNew = false;
        return (d1.countComments < d2.countComments) ? 1 : -1;
      },
    }
  }

</script>

<style>
.search {
  width: 100%;
  height: 50px;
  background-color: #353535;
  color: #FFFFFF;
  border: 0;
  padding-left: 15px;
}

.line {
  width: 100%;
  height: 12px;
  background-color: #D9D9D9;
}

.filter {
  width: 60%;
  margin-top: 20px;
  margin-left: auto;
  margin-right: auto;
  display: flex;
  justify-content: space-around;
  align-items: center;
  flex-wrap: wrap;
  gap: 2%;

}

.filter-button {
  width: 200px;
  height: 50px;
  border-radius: 5px;
  font-size: 20px;
  background-color: #C5C5C8;
  margin-bottom: 2%;
}

.filter-active {
  background-color: #FA60EA;
}

.bot-list{
  margin: 20px 0;
  display: flex;
  gap: 5%;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  padding: 0 15%;
}
</style>