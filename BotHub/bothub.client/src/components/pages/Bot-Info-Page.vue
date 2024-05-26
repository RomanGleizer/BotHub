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
      <div @click="setFavourite" v-if="!isFavourite" class="heart"><img alt="В избранное" src="@/images/favouriteEmpty.png"></div>
      <div @click="setFavourite" v-if="isFavourite" class="heart"><img alt="В избранное" src="@/images/favoriteFull.png"></div>
    </div>
    <div @click="setUserId(bot)" class="author">
      <router-link :to="{path: `/user/${thisBot.authorId}`}" class="logo">
        {{ thisBot.authorName }}
      </router-link>
    </div>
    <div class="descrip">{{ thisBot.description }}</div>
    <div class="tele-cont">
      <button class="telegram">Перейти на бота</button>
    </div>
    <div class="estimation">
      <div class="likes-dislikes">
        <div @click="setLiked" v-if="!isLiked" class="likes"><img alt="Нравится" src="@/images/likeEmpty.png">
          <p>{{ thisBot.likes }}</p></div>
        <div @click="setLiked" v-if="isLiked" class="likes"><img alt="Нравится" src="@/images/likeFull.png">
          <p>{{ thisBot.likes }}</p></div>
        <div @click="setDisliked" v-if="!isDisliked" class="likes"><img alt="Не нравится" src="@/images/dislikeEmpty.png">
          <p>{{ thisBot.dislikes }}</p></div>
        <div @click="setDisliked" v-if="isDisliked" class="likes"><img alt="Не нравится" src="@/images/dislikeFull.png">
          <p>{{ thisBot.dislikes }}</p></div>
      </div>
      <div>
        <button class="complaint">Пожаловаться на бота</button>
      </div>
    </div>
    <div>
      <textarea v-model="feedbackText" class="add-feedback" placeholder="Напишите ваше мнение по поводу бота"/>
      <button class="btn-feedback" @click="addFeedback">Отправить отзыв</button>
    </div>
  </div>
  <div v-for="feedback in feedbacks" :key="feedback.idFeedback" class="feedback">
    <FeedbackElement :feedback="feedback"></FeedbackElement>
  </div>


</template>

<script>
import FeedbackElement from "@/components/elements/Feedback-Element.vue";

export default {
  components: {
    FeedbackElement
  },
  data() {
    return {
      thisBot: this.$store.state.bot,
      feedbacks: this.$store.state.bot.feedback,
      isLiked: false,
      isDisliked: false,
      isFavourite: false,
      feedbackText: '',
    }
  },
  methods: {
    setUserId(thisBot) {
      this.$store.commit('editUserID', {value: thisBot.authorId});
      console.log(this.$store.state.userPageId)
    },
    setLiked() {
      this.isLiked = !this.isLiked;
      if (this.isLiked && this.isDisliked) {
        this.$store.state.bot.likes += 1;
        this.isDisliked = false;
        this.$store.state.bot.dislikes -= 1;
      }
      else if (!this.isLiked && !this.isDisliked) {
        this.$store.state.bot.likes -= 1;
      }
      else if (this.isLiked && !this.isDisliked) {
        this.$store.state.bot.likes += 1;
        this.isDisliked = false;
      }
    },
    setDisliked() {
      this.isDisliked = !this.isDisliked;
      if (this.isDisliked && this.isLiked) {
        this.$store.state.bot.dislikes += 1;
        this.isLiked = false;
        this.$store.state.bot.likes -= 1;
      }
      else if (!this.isDisliked && !this.isLiked) {
        this.$store.state.bot.dislikes -= 1;
      }
      else if (this.isDisliked && !this.isLiked) {
        this.$store.state.bot.dislikes += 1;
        this.isLiked = false;
      }
    },
    setFavourite() {
      this.isFavourite = !this.isFavourite;
    },
    addFeedback() {
      let feedback = {
        idFeedback: Date.now().toString(),
        author: this.$store.state.user.name,
        main: this.feedbackText,
        date: new Date().toDateString(),
      }
      if (!feedback.author) {
        feedback.author = 'Аноним'
      }
      if (feedback.main) {
        this.feedbacks.push(feedback);
        this.feedbackText = '';
      }
    }
  }
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

.avatar-image {
  border-radius: 50%;
}

.author {
  margin-bottom: 5%;
}

.logo, .logo:active {
  text-decoration: none;
  font-size: 26px;
  font-weight: bold;
  color: #9ABBD9;
}

.logo:hover {
  color: #BC28C9;
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

.add-feedback {
  width: 100%;
  max-width: 1200px;
  height: 250px;
  padding: 25px;
}

.btn-feedback {
  padding: 10px;
  border-radius: 5px;
  background-color: #7b36df;
  color: #D9D9D9;
}

.btn-feedback:hover {
  background-color: #8274D9;
  color: black;
}
</style>