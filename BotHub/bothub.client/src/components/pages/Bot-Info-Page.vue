<template>
  <div class="container">
    <button @click="whatBot">Что за бот?</button>
    <div class="bot-author">
      <div class="avatar"><img class="avatar-image" src="@/images/avatar.png" alt="Аватар" width="50"></div>
      <div class="name">{{bot.name}}</div>
    </div>

    <div class="author">
      <div class="nickname">{{bot.authorName}}</div>
      <div class="rating"> рейтинг: <span class="rating-gold">{{bot.rating}}</span></div>
    </div>

    <div class="info">
      <div class="tags"><span class="tag-one">#{{bot.tagOne}}</span> <span class="tag-two">#{{bot.tagTwo}}</span></div>
      <div class="count">{{bot.countComments}} {{bot.countRatings}}</div>
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
      "countRatings": 0,
      "authorName": ""
    }
  },
  data() {
    return {
        thisBot: {
        "id": 0,
        "name": "Bot-Name",
        "rating": 1,
        "tagOne": "Тег",
        "tagTwo": "НеТег",
        "countComments": 2,
        "countRatings": 1,
        "authorName": "Katya"
      }
    }
  },
  methods: {
    whatBot() {
      console.log(this.bot);
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
</style>