<template>
  <div class="container">
    <div class="bot-author">
      <div class="avatar"><img alt="Аватар" class="avatar-image" src="@/images/avatar.png" width="50"></div>
      <div class="name">{{ bot.name }}</div>
    </div>

    <div class="author">
      <div class="nickname">
        <router-link @click="setUserId(bot)" :to="{path: `/user/${bot.authorId}`}" class="logo">
          {{ bot.authorName }}
        </router-link>
      </div>
      <div class="rating"> рейтинг: <span
          :class="{'rating-green': bot.likes-bot.dislikes > 0, 'rating-red': bot.likes-bot.dislikes < 0}">{{
          bot.likes - bot.dislikes
        }}</span>
      </div>
    </div>

    <div class="desc">{{ bot.miniDescription }}</div>
    <router-link :bot="bot" :to="{path: `/bot/${bot.id}`}">
      <button class="more">Подробнее</button>
    </router-link>

    <div class="info">
      <div class="tags"><span class="tag-one">#{{ bot.tagOne }}</span> <span class="tag-two">#{{ bot.tagTwo }}</span>
      </div>
      <div class="count">
        <div>
          <img alt="Отзывы" height="21" src="@/images/feedback.png">
          <p>{{ bot.countComments }}</p>
        </div>
        <div>
          <img alt="Оценки" height="21" src="@/images/rating.png">
          <p>{{ bot.likes + bot.dislikes }}</p>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
export default {

  props: {
    bot: {
      "id": 0,
      "name": "",
      "miniDescription": "",
      "rating": 0,
      "tagOne": "",
      "tagTwo": "",
      "countComments": 0,
      "likes": 0,
      "dislikes": 0,
      "authorName": ""
    }
  },
  methods: {
    setUserId(thisBot) {
      this.$store.commit('editUser', {value: thisBot.authorId});
      console.log(this.$store.state.userPageId)
    }
  }
}
</script>

<style scoped>
.container {
  display: flex;
  flex-direction: column;
  width: 100%;
  max-width: 500px;
  background: #353535;
  padding: 20px 15px;
  color: #EAEAEA;
  border: #B5B5B5 1px solid;
  box-shadow: 12px 12px 2px 1px rgba(63, 63, 106, 0.7);
  margin-bottom: 5%;
}

.bot-author {
  display: flex;
  gap: 15px;
}

.author {
  display: flex;
  justify-content: space-between;
  font-size: 24px;
}

.info {
  display: flex;
  justify-content: space-between;
  font-size: 24px;
  margin: 0 0 0 10px;
}

.avatar-image {
  border-radius: 50%;
}

.name {
  font-size: 36px;
}

.desc {
  font-size: 20px;
  margin: 15px 0 0 10px;
}

.more {
  width: 130px;
  font-size: 18px;
  padding: 8px;
  border-radius: 10px;
  margin: 15px 0 15px 10px;
  background-color: #D9D9D9;
}

.nickname {
  margin: 10px 0 0 10px;
}

.tag-one {
  color: #AF6EB7;
}

.tag-two {
  color: #D697B5;
}

.rating-gold {
  color: #E2D02E;
  font-size: 26px;
}

.count {
  display: flex;
  gap: 10px;
}

.rating-green {
  color: green;
}

.rating-red {
  color: red;
}
</style>