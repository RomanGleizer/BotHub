<template>
  <div class="container-feedback">
    <div class="author-feedback">
      <img alt="Аватар" class="feedback-avatar" src="../../images/avatar.png" width="78">
      {{ feedback.author }}
    </div>
    <div class="main-feedback">{{ feedback.main }}</div>
    <div class="date">{{ feedback.date }}</div>
  </div>
  <div class="line"></div>
</template>

<script>
export default {
  props: {
    feedback: {
      "idFeedback": 0,
      "author": "",
      "main": "",
      "date": ""
    }
  }
}
</script>

<style scoped>
.container-feedback {
  padding: 2%;
  background-color: #D9D9D9;
  color: #000000;
  font-size: 24px;
}

.line {
  height: 5px;
  background-color: #353535;
}

.author-feedback {
  align-items: center;
  margin-bottom: 15px;
  display: flex;
  gap: 20px;
  font-size: 26px;
}

.main-feedback {
  margin-bottom: 15px;
  margin-left: 80px;
  margin-right: 150px;
  font-size: 22px;
}

.feedback-avatar {
  border-radius: 50%;
}

.date {
  display: flex;
  justify-content: end;
  font-size: 20px;
}
</style>