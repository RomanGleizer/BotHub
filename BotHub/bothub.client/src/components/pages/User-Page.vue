<template>
  <div class="user-cont">
    <div class="user">
      <div class="user-avatar">
        <img alt="Аватар" class="avatar-image" src="@/images/avatar.png" width="150">
      </div>
      <div class="user-info">
        <p class="name">{{this.name}}</p>
        <p class="email">{{this.email}}</p>
        <p class="time">Зарегистрирован 23.04.2024г.</p>
        <p class="info">{{this.about}}</p>
      </div>
    </div>
    <div class="bot-list">
      <div class="filter">
        <button :class="{'filter-active': isAdded}" class="filter-button" @click="sortParam='added'">Популярное</button>
        <button :class="{'filter-active': isLike}" class="filter-button" @click="sortParam='like'">Новинки</button>
      </div>
      <div v-for="bot in sortedList" :key="bot.id" class="bot-card">
        <BotCardElement :bot="bot"></BotCardElement>
      </div>
    </div>
  </div>
</template>

<script>

import BotCardElement from "@/components/elements/Bot-Card-Element.vue";
import BotList from "@/botList.json";

export default {
  components: {
    BotCardElement
  },
  data() {
    return {
      botList: BotList,
      email: 'ezekiel@mail.ru',
      name: 'Ezekiel',
      about: 'Информация о себе',
      sortParam: '',
      isAdded: true,
      isLike: false
    }
  },
  computed: {
    sortedList() {
      switch (this.sortParam) {
        case 'added':
          return this.botList.filter(bot => {
            return bot.authorName == this.name;
          }).sort(this.sortByAdded);
        case 'like':
          return this.botList.filter(bot => {
            return bot.authorName == 'Roman';
          }).sort(this.sortByLike);
        default:
          return this.botList.filter(bot => {
            return bot.authorName == this.name;
          }).sort(this.sortByAdded);
      }
    },
  },
  methods: {
    sortByAdded() {
      this.isAdded = true;
      this.isLike = false;
    },
    sortByLike() {
      this.isAdded = false;
      this.isLike = true;
    },
  }
}
</script>

<style scoped>
  .user-cont {
    width: 80%;
    margin: 0 auto;
    height: 100%;
    background-color: #353535;
    color: #D9D9D9;
  }

  .avatar-image {
    border-radius: 50%;
  }

  .user {
    display: flex;
    align-items: center;
    gap: 25px;
    margin-left: 100px;
    padding-top: 25px;
  }

  .name {
    font-size: 36px;
    margin-bottom: 10px;
  }

  .email {
    font-size: 24px;
    color: #9ABBD9;
    margin-bottom: 10px;
  }

  .time {
    font-size: 20px;
    margin-bottom: 10px;
  }

  .info {
    font-size: 24px;
  }

</style>