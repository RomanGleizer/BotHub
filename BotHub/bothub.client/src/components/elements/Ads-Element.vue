<template>
  <div class="ads-container">
    <div class="ads-text">
      <h3 class="ads-h3">Info-bot</h3>
      <div class="ads-info">
        Привет, роботы! Самые актуальные новинки в мире технологий уже здесь!
        Специально для вас: абсолютно новые алгоритмы машинного обучения, умные дроны.
      </div>
      <button class="ads-more">Подробнее</button>
    </div>
    <div class="ads-image">
      <img src="@/images/info-bot.png" alt="Фотография бота" width="400" height="250" />
    </div>
  </div>
</template>

<script>
  export default {}
</script>

<style scoped>
  .ads-container {
    width: 100%;
    min-height: 300px;
    padding: 0 100px;
    background-color: #353535;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    align-items: center;
    gap: 20px;
  }

  .ads-text {
    width: 45%;
  }

  .ads-h3 {
    font-size: 40px;
    color: #EAEAEA;
    margin-bottom: 10px;
  }
  .ads-info {
    max-width: 450px;
    font-size: 20px;
    color: #EAEAEA;
    margin-bottom: 10px;
  }

  .ads-more {
    background-color: #8274D9;
    color:#282829;
    width: 150px;
    height: 40px;
    border: none;
    border-radius: 5px;
    font-size: 14px;
  }
</style>