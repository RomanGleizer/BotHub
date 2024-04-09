<template>
  <div class="app-flex">
    <div class="header">
      <HeaderElement/>
    </div>
    <div class="main">
      <router-view></router-view>
    </div>
    <div class="footer">
      <FooterElement/>
    </div>
  </div>
</template>

<script lang="ts">
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

html,
body,
#app {
  height: 100%;
}

.app-flex {
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.header {
  width: 100%;
}

.footer {
  width: 100%;
  flex: 0 0 auto;
}

.main {
  flex: 1 0 auto;
  background-color: #8274D9;
  width: 100%;
}
</style>