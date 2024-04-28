<template>
  <div class="container">
    <div class="bot-author">
      <div class="author-info">
        <div class="avatar"><img alt="Аватар" class="avatar-image" src="@/images/avatar.png" width="150"></div>
        <div class="name">{{ thisBot.name }}</div>
      </div>
      <div class="rating"> рейтинг: <span
          :class="{'rating-green': thisBot.likes-thisBot.dislikes > 0, 'rating-red': thisBot.likes-thisBot.dislikes < 0}">{{
          thisBot.likes - thisBot.dislikes
        }}</span>
      </div>
      <div class="heart"><img alt="В избранное" src="@/images/favorite.png"></div>
    </div>
    <div class="author">
      <div class="nickname">{{ thisBot.authorName }}</div>
    </div>
    <div class="descrip">{{ thisBot.description }}</div>
    <div class="tele-cont">
      <button class="telegram">Перейти на бота</button>
    </div>
    <div class="estimation">
      <div class="likes-dislikes">
        <div class="likes"><img alt="Нравится" src="@/images/like.png">
          <p>{{ thisBot.likes }}</p></div>
        <div class="likes"><img alt="Не нравится" src="@/images/dislike.png">
          <p>{{ thisBot.dislikes }}</p></div>
      </div>
      <div>
        <button class="complaint">Пожаловаться на бота</button>
      </div>
    </div>
  </div>
  <div v-for="feedback in feedbacks" :key="feedback.idFeedback" class="feedback">
    <FeedbackElement :feedback="feedback"></FeedbackElement>
  </div>

</template>

<script>
import FeedbackElement from "@/components/elements/Feedback-Element.vue";
import Feedbacks from "@/feedbacks.json";

export default {
  components: {
    FeedbackElement
  },
  data() {
    return {
      feedbacks: Feedbacks,
      thisBot: {
        "id": 0,
        "name": "Bot-Name",
        "rating": 1,
        "description": 'Привет! Я - твой верный информационный бот Юки! Со мной ты можешь узнать всю необходимую информацию, задавай вопросы и я с удовольствием помогу. Буду рада помочь тебе в любое время дня и ночи! Погнали искать ответы на твои вопросы вместе!',
        "tagOne": "Тег",
        "tagTwo": "НеТег",
        "countComments": 2,
        "likes": 1,
        "dislikes": 0,
        "authorName": "Katya"
      }
    }
  },
  methods: {}
}
</script>

<style scoped>
.container {
  width: 100%;
  max-width: 1200px;
  background: #353535;
  padding: 30px 30px;
  color: #EAEAEA;
  margin-left: auto;
  margin-right: auto;
  font-size: 24px;
}

.rating-green {
  color: green;
}

.rating-red {
  color: red;
}

.bot-author {
  display: flex;
  flex-wrap: wrap;
  gap: 15px;
  justify-content: space-between;
  align-items: center;
}

.author-info {
  display: flex;
  gap: 15px;
  align-items: center;
}

.name {
  font-size: 50px;
}

.nickname {
  font-size: 20px;
}

.avatar-image {
  border-radius: 50%;
}

.author {
  margin-bottom: 5%;
}

.descrip {
  margin-bottom: 5%;
}

.tele-cont {
  width: 300px;
  margin-left: auto;
  margin-right: auto;
}

.telegram {
  margin-bottom: 5%;
  background-color: #E217F3;
  width: 300px;
  height: 60px;
  align-items: center;
  font-size: 30px;
  border-radius: 5px;
}

.estimation {
  display: flex;
  justify-content: space-between;
  margin-bottom: 3%;
}

.likes-dislikes {
  display: flex;
  gap: 10px;
}

.complaint {
  background-color: #ffab8e;
  border-radius: 5px;
  width: 100px;
}

.feedback {
  width: 100%;
  max-width: 1200px;
  margin-left: auto;
  margin-right: auto;
}

.likes {
  text-align: center;
  margin-right: 10px;
}
</style>