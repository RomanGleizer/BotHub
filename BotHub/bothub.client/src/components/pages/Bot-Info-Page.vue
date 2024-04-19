<template>
  <div class="container">
    <div class="bot-author">
      <div class="author-info">
        <div class="avatar"><img class="avatar-image" src="@/images/avatar.png" alt="Аватар" width="50"></div>
        <div class="name">{{thisBot.name}}</div>
      </div>
      <div class="rating"> рейтинг: <span class="rating-green">{{thisBot.rating}}</span></div>
      <div class="heart"> *3 </div>
    </div>

    <div class="author">
      <div class="nickname">{{thisBot.authorName}}</div>
    </div>
    <div class="descrip">{{thisBot.description}}</div>

    <div class="info">
      <div class="tags"><span class="tag-one">#{{thisBot.tagOne}}</span> <span class="tag-two">#{{thisBot.tagTwo}}</span></div>
      <div class="count">{{thisBot.countComments}} {{thisBot.countRatings}}</div>
    </div>
  </div>

</template>

<script>
export default {
    data() {
    return {
        thisBot: {
        "id": 0,
        "name": "Bot-Name",
        "rating": 1,
        "description": 'Привет! Я - твой верный информационный бот Юки! Со мной ты можешь узнать всю необходимую информацию, задавай вопросы и я с удовольствием помогу. Буду рада помочь тебе в любое время дня и ночи! Погнали искать ответы на твои вопросы вместе!',
        "tagOne": "Тег",
        "tagTwo": "НеТег",
        "countComments": 2,
        "countRatings": 1,
        "authorName": "Katya"
      }
    }
  },
  methods: {
  }
}
</script>

<style scoped>
.container {
  width: 100%;
  max-width: 1200px;
  background: #353535;
  padding: 20px 15px;
  color: #EAEAEA;
  margin-left: auto;
  margin-right: auto;
  margin-bottom: 5%;
  text-align: center;
}

.bot-author {
  display: flex;
  gap: 15px;
  justify-content: space-between;
}

.author {
  display: flex;
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