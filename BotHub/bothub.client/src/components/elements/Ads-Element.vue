<template>
  <div class="container">
    <div class="text">
      <h3 class="h">Info-bot</h3>
      <div class="info">
        Привет, роботы! Самые актуальные новинки в мире технологий уже здесь!
        Специально для вас: абсолютно новые алгоритмы машинного обучения, умные дроны.
      </div>
      <button class="more">Подробнее</button>
    </div>
    <div class="image">
      <img src="@/images/info-bot.png" alt="Фотография бота" width="400" />
    </div>
  </div>
</template>

<script>
  export default {}
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
    color:#282829;
    width: 150px;
    height: 40px;
    border: none;
    border-radius: 5px;
    font-size: 14px;
  }
</style>