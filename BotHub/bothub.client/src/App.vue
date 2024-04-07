<template>
  <div class="header">
    <HeaderElement />
  </div>
  <div class="main">
    <router-view></router-view>
  </div>
  <FooterElement />
</template>

<script>
  import HeaderElement from './components/elements/Header-Element.vue'
  import FooterElement from "@/components/elements/Footer-Element.vue";

  export default {
    components: {
      HeaderElement,
      FooterElement,
    }
  }
</script>

<style>
  * {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
  }
</style>