<template>
  <div class="container">
    <div v-if="this.$store.state.isLogin" class="bot-adding">
      <router-link :to="{ path: '/addBot' }">
        <img alt="Добавить бота" height="35" src="../../images/bot-add.svg" width="45">
      </router-link>
    </div>
    <div v-if="!this.$store.state.isLogin" class="btn-bot-adding">
      <router-link :to="{ path: '/login' }">
        <button class="btn-bot-adding">Войдите, чтобы добавить бота</button>
      </router-link>
    </div>
    <div>
      <router-link :to="{path: `/`}" class="logo">
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
export default {}
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

.btn-bot-adding {
  width: 155px;
  height: 35px;
}

.btn-bot-adding:hover {
  background-color: #8274D9
}
</style>