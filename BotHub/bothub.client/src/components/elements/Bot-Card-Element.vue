<template>
  <div class="container">
    <div class="avatar">Картинка</div>
    <div class="name">{{bot.name}}</div>
    <div class="nickname">{{bot.authorName}}</div>
    <div class="rating">{{bot.rating}}</div>
    <div class="desc">{{bot.miniDescription}}</div>
    <button>Подробнее</button>
    <div class="tags">#{{bot.tagOne}} #{{bot.tagTwo}}</div>
    <div class="count">{{bot.countComments}}</div>
    <div class="count">{{bot.countRatings}}</div>
  </div>

</template>

<script>
  export default {

    props: {
      bot: Object
    },
    methods: {
      
    }
  }
</script>

<style scoped>
  .container {
    display: grid;
  }
</style>