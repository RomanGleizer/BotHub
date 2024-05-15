<template>
  <div class="container">
    <div class="text">
      <h3 class="h">{{ bot.name }}</h3>
      <div class="info">{{ bot.miniDescription }}</div>
      <router-link :bot="bot" :to="{path: `/bot/${bot.id}`}">
        <button class="more">Подробнее</button>
      </router-link>
    </div>
    <div class="image">
      <img alt="Фотография бота" src="@/images/info-bot.png" width="400"/>
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
}
</script>

<style scoped>
.container {
  width: 100%;
  min-height: 300px;
  padding: 2% 10%;
  background-color: #353535;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  gap: 20px;
}

.text {
  max-width: 600px;
}

.h {
  font-size: 40px;
  color: #EAEAEA;
  margin-bottom: 10px;
}

.info {
  max-width: 450px;
  font-size: 20px;
  color: #EAEAEA;
  margin-bottom: 10px;
}

.more {
  background-color: #8274D9;
  color: #282829;
  width: 150px;
  height: 40px;
  border: none;
  border-radius: 5px;
  font-size: 14px;
}

.more:hover {
  color: #D9D9D9;
  background-color: #1b0b31;
}
</style>