<template>
  <div class="container">
    <div class="bot-adding">
      <RouterLink to="/addBot">
        <img src="../../images/bot-add.svg" alt="Добавить бота" width="45" height="35">
      </RouterLink>
    </div>
    <div>
      <RouterLink class="logo" to="/">
        Bot<b>Hub</b>
      </RouterLink>
    </div>
    <div class="authorization">
      <RouterLink to="/login">
        <button>Войти</button>
      </RouterLink>
    </div>
  </div>
</template>

<script>
  export default {

  }
</script>

<style scoped>
  .container {
    background: #EAEAEA;
    height: 60px;
    display: flex;
    justify-content: space-around;
    align-items: center;
  }

  .logo {
    text-align: center;
    font-size: 45px;
    text-decoration: none;
  }
</style>