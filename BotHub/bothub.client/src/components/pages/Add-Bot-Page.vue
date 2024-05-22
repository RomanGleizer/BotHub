<template>
  <div class="add-cont">
      <form class="add-bot-form" v-on:submit.prevent="addData">
        <input class="input" v-model="name" type="text" placeholder="Введите название бота">

        <div class="input-div">
          <p class="note">По данному полю будет идти поиск. Убедитесь, что вписываете ключевую информацию о нем.</p>
          <textarea class="textarea" v-model="microDesc" placeholder="Введите краткую информацию о боте" />
        </div>

        <div class="input-div">
          <p class="note">Здесь можете подробнее расписать функционал и возможности вашего бота.</p>
          <textarea class="textarea" v-model="allDesc" placeholder="Введите полное описание" />
        </div>

        <input class="input" v-model="botUrl" type="text" placeholder="Вставьте ссылку на бота">

        <input class="input" v-model="avatarUrl" type="text" placeholder="Вставьте ссылку на иконку бота">

        <button type="submit" class="add-btn">Опубликовать бота</button>
      </form>
  </div>
</template>

<script>
  import router from "@/router/index.js";

  export default {
    data() {
      return {
        name: '',
        microDesc: '',
        allDesc: '',
        botUrl: '',
        avatarUrl: ''
      }
    },
    methods: {
      addData() {
        let bot = {
          "id": Date.now(),
          "name": this.name,
          "miniDescription": this.microDesc,
          "likes": 0,
          "dislikes": 0,
          "authorName": this.$store.state.name,
          "authorId": 100,
          "date": new Date().toDateString(),
          "description": this.allDesc,
          "feedback": []
        };
        console.log(bot);
        this.$store.commit('addToBotList', {value: bot});
        router.push(`/`);
      }
    }
  }
</script>

<style>
  .add-cont {
    width: 80%;
    margin: 0 auto;
    height: 100%;
    background-color: #353535;
  }

  .add-bot-form {
    padding: 2% 0;
    display: flex;
    flex-direction: column;
    justify-content: space-around;
    min-height: 100%;
    align-items: center;
  }

  .input {
    width: 80%;
    height: 45px;
    border-radius: 15px;
  }

  .input-div{
    width: 80%;
  }

  .textarea{
    width: 100%;
    height: 100px;
    padding-top: 2%;
  }

  .input, .textarea {
    background: #D9D9D9;
    border-radius: 15px;
    padding-left: 2%;
    border: 0;
  }

  .note {
    color: #D9D9D9;
    padding: 10px;
  }

  .add-btn {
    background: #BC28C9;
    width: 50%;
    font-size: 24px;
    padding-top: 1%;
    padding-bottom: 1%;
    border-radius: 15px;
    border: 0;
  }
</style>