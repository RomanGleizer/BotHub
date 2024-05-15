<template>
  <div class="login-container">
    <div class="enter">Регистрация</div>
    <form class="form-login" v-on:submit.prevent="registerData">
      <input v-model="login" class="input-form" placeholder="Логин пользователя" required type="text">
      <input v-model="email" class="input-form" placeholder="E-mail пользователя" required type="email">
      <input v-model="password" class="input-form" placeholder="Пароль" required type="password">
      <input v-model="repeatedPassword" class="input-form" placeholder="Повторите пароль" required type="password">
      <button type="submit" class="enter-btn">Зарегистрироваться</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: '',
      login: '',
      password: '',
      repeatedPassword: ''
    }
  },
  methods: {
    async registerData() {
      let user = {
        login: this.login,
        email: this.email,
        password: this.password,
        repeatedPassword: this.repeatedPassword
      };
      console.log(user);
      let requestOptions = {
        method: "POST",
        headers: { Accept: "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(user),
      };
      // eslint-disable-next-line no-unused-vars
      const response = await fetch("https://localhost:7233/api/Users/register", requestOptions)
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