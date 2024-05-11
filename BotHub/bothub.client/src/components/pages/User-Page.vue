<template>
  <div class="user-cont">
    <div class="user">
      <div class="user-avatar">
        <img alt="Аватар" class="avatar-image" src="@/images/avatar.png" width="150">
      </div>
      <div class="user-info">
        <p>Имя</p>
        <p>email</p>
        <p>Зарегистрирован 23.04.2024г.</p>
        <p>О себе</p>
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
      name: 'Ezekiel',
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
  }

  .avatar-image {
    border-radius: 50%;
  }
</style>