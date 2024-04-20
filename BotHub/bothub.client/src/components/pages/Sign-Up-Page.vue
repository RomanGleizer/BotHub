<template>
  <div class="login-container">
    <div class="enter">Регистрация</div>
    <form @submit.prevent class="form-login">
      <input class="input-form" required type="text" v-model="login" placeholder="Логин пользователя">
      <input class="input-form" required type="email" v-model="email" placeholder="E-mail пользователя">
      <input class="input-form" required type="password" v-model="password" placeholder="Пароль">
      <input class="input-form" required type="password" v-model="password" placeholder="Повторите пароль">
      <button class="enter-btn">Зарегистрироваться</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: '',
      login: '',
      password: ''
    }
  }
}
</script>

<style scoped>
.login-container {
  margin-top: 2%;
  margin-bottom: 10px;
  width: 500px;
  height: 550px;
  background-image: url("@/images/signup-back.jpg");
  margin-right: auto;
  margin-left: auto;
  background-size: 100%;
  color: #EAEAEA;
  padding-top: 35px;
}

.form-login {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin-top: 50px;
  margin-bottom: 10px;
  gap: 15px;
}

.enter-btn {
  width: 350px;
  height: 50px;
  background-color: #CA27D8E8;
  font-size: 24px;
  color: #EAEAEA;
  border-radius: 5px;
  margin-top: 40px;
}

.input-form {
  width: 350px;
  height: 50px;
  border-radius: 5px;
  padding-left: 10px;
  padding-right: 10px;
}

.enter {
  text-align: center;
  font-size: 50px;
}
</style>