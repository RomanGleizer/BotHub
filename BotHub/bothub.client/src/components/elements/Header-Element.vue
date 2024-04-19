<template>
  <div class="container">
    <div class="bot-adding">
      <router-link :to="{ path: '/addBot' }">
        <img alt="Добавить бота" height="35" src="../../images/bot-add.svg" width="45">
      </router-link>
    </div>
    <div>
      <router-link class="logo" :to="{path: `/`}">
        Bot<b>Hub</b>
      </router-link>
    </div>
    <div class="authorization">
      <router-link :to="{path: `/login`}">
        <button class="button-login">Войти</button>
      </router-link>
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
  color: black;
}

.bot-adding {
  width: 45px;
  height: 35px;
}

.bot-adding:hover {
  background-color: #8274D9;
}

.button-login {
  padding: 5px 15px;
}

.button-login:hover {
  background-color: #8274D9;
}
</style>