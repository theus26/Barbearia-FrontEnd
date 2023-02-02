<template>

  <TelaLogin />

</template>

<script>
import { defineComponent } from "vue";

// Components
import TelaLogin from "./TelaLogin.vue";


export default defineComponent({
  name: "HomeView",

  components: {
    TelaLogin,

  },
});
</script>
