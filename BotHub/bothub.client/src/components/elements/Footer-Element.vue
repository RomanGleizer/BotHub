<template>
  <div class="container">
    <div class="rules">
      <p>Правила использования</p>
    </div>
    <div class="contacts">
      <p class="phone">+7-900-000-00-00</p>
    </div>
    <div class="copyright">
      <p>©arahis</p>
    </div>
  </div>
  <div class="site-container">
    arahis.com
  </div>
</template>

<script>
export default {

}
</script>

<style scoped>
  .container {
    background: #353535;
    height: 60px;
    display: flex;
    flex-wrap: wrap;
    justify-content: space-around;
    align-items: center;
    color: #FFFFFF;
    font-size: 16px;
  }

  .site-container {
    background-color: #8274D9;
    align-items: center;
    display: flex;
    justify-content: center;
    color: #FFFFFF;
    font-size: 16px;
  }

  .rules, .contacts, .copyright {
    flex: 1 1 auto;
    text-align: center;
    width: 33%;
  }
</style>