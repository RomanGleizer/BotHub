<template>
  <div class="user-cont">
    <div class="user">
      <div class="user-avatar">
        <img alt="Аватар" class="avatar-image" src="@/images/avatar2.png" width="200">
        <p class="time">Дата регистрации 23.04.2024г.</p>
      </div>
      <div class="user-info">
        <p class="name">{{this.author.name}}</p>
        <p class="email">{{this.author.email}}</p>
        <p class="info">{{this.author.info}}</p>
      </div>
      <div :class="{'hidden': !isLoginUser}" class="exit">
        <button class="exit-btn" @click="stateData">Выйти</button>
      </div>
    </div>
    <div class="bot-list">
      <div class="filter">
        <button :class="{'filter-active': sortParam!='like'}" class="filter-button" @click="sortParam='added'">Добавленное</button>
        <button :class="{'filter-active': sortParam=='like'}" class="filter-button" @click="sortParam='like'">Любимые</button>
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
import router from "@/router/index.js";

export default {
  components: {
    BotCardElement
  },
  data() {
    return {
      botList: BotList,
      author: this.$store.state.author,
      sortParam: '',
      isAdded: true,
      isLike: false,
      isLoginUser: this.$store.state.userPageId === this.$store.state.loginId,
    }
  },
  computed: {
    sortedList() {
      switch (this.sortParam) {
        case 'added':
          return this.botList.filter(bot => {
            return bot.authorId == this.$store.state.userPageId;
          });
        case 'like':
          return this.botList.filter(bot => {
            return bot.authorName == "Roman";
          });
        default:
          return this.botList.filter(bot => {
            return bot.authorId == this.$store.state.userPageId;
          });
      }
    },
  },
  methods: {
    stateData() {
      router.push(`/`);
      this.$store.commit('editIsLogin', {value: false});
      this.$store.commit('editLogin', {value: 0});
      this.$store.commit('editName', {value: ''});
    }
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

  .user-avatar {
    width: 210px;
  }

  .avatar-image {
    border-radius: 50%;
    background-color: white;
  }

  .user {
    display: flex;
    gap: 25px;
    margin-left: 100px;
    padding-top: 40px;
  }

  .user-info {
    display: flex;
    flex-direction: column;
    justify-content: start;
  }

  .name {
    font-size: 48px;
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
    text-align: center;
  }

  .info {
    font-size: 24px;
  }

  .hidden {
    display: none;
  }

  .exit-btn {
    margin-left: 500px;
    width: 50px;
    height: 30px;
  }

  .exit-btn:hover {
    background-color: #FA60EA;
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

  .filter-button:hover {
    color: #7b36df;
  }

  .filter-active {
    background-color: #FA60EA;
  }

  .bot-list {
    margin: 20px 0;
    display: flex;
    gap: 5%;
    flex-wrap: wrap;
    justify-content: center;
    align-items: center;
    padding: 0 15%;
  }
</style>