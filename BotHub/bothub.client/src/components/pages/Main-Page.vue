<template>
  <div class="search-container">
    <input class="search" placeholder="введите название бота или краткую информацию" type="text">
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
      <swiper-slide>
        <AdsElement></AdsElement>
      </swiper-slide>
      <swiper-slide><AdsElement></AdsElement></swiper-slide>
      <swiper-slide><AdsElement></AdsElement></swiper-slide>
      ...
    </swiper>
  </div>
  <div class="filter">
    <button class="filter-button filter-active">Популярное</button>
    <button class="filter-button">Новинки</button>
    <button class="filter-button">Лайки?</button>
  </div>
  <div class="bot-list">
    <div class="bot-card" v-for="bot in botList" :key="bot.id">
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

  export default {
    data() {
      return {
        botList: BotList
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