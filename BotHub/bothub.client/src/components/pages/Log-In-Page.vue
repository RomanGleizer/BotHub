<template>
  <div class="login-container">
    <div class="enter">Вход</div>
    <form class="form-login" v-on:submit.prevent="loginData">
      <input v-model="email" class="input-form" placeholder="E-mail пользователя" required type="email">
      <input v-model="password" class="input-form" placeholder="Пароль" required type="password">
      <button type="submit" class="enter-btn">Войти</button>
    </form>
    <div class="help">
      <router-link :to="{path: '/signUp'}" class="register">Регистрация</router-link>
      <a>Забыли пароль?</a>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: '',
      password: ''
    }
  },
  methods: {
    async loginData() {
      let user = {
        userName: this.email,
        password: this.password,
        rememberMe: true
      };
      console.log(user);
      let requestOptions = {
        method: "POST",
        headers: { Accept: "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(user),
      };
      // eslint-disable-next-line no-unused-vars
      const response = await fetch("https://localhost:7233/api/Users", requestOptions)
          .then((response) => {
            if (response.ok) {
              console.log(response);
            } else {
              throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
          })
          .then((data) => {
            console.log(data);
            console.log(user);
          });
    }
  }
}
</script>

<style scoped>
.login-container {
  margin-top: 2%;
  margin-bottom: 10px;
  width: 500px;
  height: 500px;
  background-image: url("@/images/login-back.jpg");
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

.help {
  width: 350px;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  align-items: center;
  margin: 0 auto;
}

.register, .register:active {
  color: #EAEAEA;
  text-decoration: none;
}

.register:hover {
  font-weight: bold;
}
</style>