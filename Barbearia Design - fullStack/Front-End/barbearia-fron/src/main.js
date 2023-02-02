import { createApp } from "vue";

import App from "./App.vue";
import router from "./router";
import vuetify from "./plugins/vuetify";
import { loadFonts } from "./plugins/webfontloader";
import "./assets/tailwind.css";
import VueTheMask from 'vue-the-mask'
import VueSweetalert2 from "vue-sweetalert2";
import "sweetalert2/dist/sweetalert2.min.css";



loadFonts();

createApp(App).use(router).use(vuetify).use(VueTheMask).use(VueSweetalert2).mount("#app");
