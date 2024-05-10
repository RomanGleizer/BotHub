<template>
  <div class="user-cont">
    ЭТО ЮЗЕР
    <div class="user">
      <div class="user-avatar"></div>
      <div class="user-info"></div>
    </div>
    <div class="bot-list">
      <div v-for="bot in searchList" :key="bot.id" class="bot-card">
        <BotCardElement :bot="bot"></BotCardElement>
      </div>
    </div>
  </div>
</template>

<script>

import BotCardElement from "@/components/elements/Bot-Card-Element.vue";
import BotList from "@/botList.json";

export default {
  components: {
    BotCardElement
  },
  data() {
    return {
      botList: BotList,
      name: 'Ezekiel'
    }
  },
  computed: {
    searchList() {
      return this.botList.filter(bot => {
        return bot.authorName == this.name;
      })
    }
  }
}
</script>

<style scoped>

</style>