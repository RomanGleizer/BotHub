<template>
  <div class="search-container">
    <input class="search" placeholder="введите название бота или краткую информацию" type="text">
  </div>
<div class="line"></div>
  <div class="swiper">
    <swiper
        :modules="modules"
        :slides-per-view="1"
        :space-between="500"
        :loop="true"
        navigation
        :pagination="{ clickable: true }"
        @swiper="onSwiper"
        @slideChange="onSlideChange"
    >
      <swiper-slide>
        <AdsElement></AdsElement>
      </swiper-slide>
      <swiper-slide><AdsElement></AdsElement></swiper-slide>
      <swiper-slide><AdsElement></AdsElement></swiper-slide>
      ...
    </swiper>
  </div>
<!--  <div>Фильтрация</div>-->
<!--  <div>Список ботов</div>-->
</template>

<script>
import { Navigation, Pagination, Scrollbar, A11y } from 'swiper/modules';
  import { Swiper, SwiperSlide } from 'swiper/vue';
  import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';
import 'swiper/css/scrollbar';

import AdsElement from "@/components/elements/Ads-Element.vue";

  export default {

    components: {
      AdsElement,
      Swiper,
      SwiperSlide,
    },
    setup() {
      const onSwiper = (swiper) => {
        console.log(swiper);
      };
      const onSlideChange = () => {
        console.log('slide change');
      };
      return {
        onSwiper,
        onSlideChange,
        modules: [Navigation, Pagination, Scrollbar, A11y],
      };
    },
}
</script>

<style>
.search {
  width: 100%;
  height: 50px;
  background-color: #353535;
  color: #FFFFFF;
  border: 0;
  padding-left: 15px;
}

.line {
  width: 100%;
  height: 12px;
  background-color: #D9D9D9;
}
</style>