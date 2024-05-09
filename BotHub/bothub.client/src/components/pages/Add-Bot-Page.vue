<template>
  <div class="add-cont">
    <div class="bot-info">
      <form class="add-bot-form" v-on:submit.prevent="addData">
        <input class="input" v-model="name" type="text" placeholder="Введите название бота">

        <p>По данному полю будет идти поиск. Убедитесь, что вписываете ключевую информацию о нем.</p>
        <textarea class="input" v-model="microDesc" placeholder="Введите краткую информацию о боте" />

        <p>Здесь можете подробнее расписать функционал и возможности вашего бота.</p>
        <textarea class="input" v-model="allDesc" placeholder="Введите полное описание" />

        <input class="input" v-model="botUrl" type="text" placeholder="Вставьте ссылку на бота">

        <input class="input" v-model="avatarUrl" type="text" placeholder="Вставьте ссылку на иконку бота">

        <button type="submit" class="add-btn">Опубликовать бота</button>
      </form>
    </div>
  </div>
</template>

<script>
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
          name: this.name,
          microDesc: this.microDesc,
          allDesc: this.allDesc,
          botUrl: this.botUrl,
          avatarUrl: this.avatarUrl
        };
        console.log(bot)
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
    display: grid;
  }

  .input {
    max-width: 500px;
  }
</style>