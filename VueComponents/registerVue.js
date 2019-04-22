import Vue from 'vue'

// import VeeValidate from 'vee-validate';
// Vue.use(VeeValidate);

import Vuetify from 'vuetify';
Vue.use(Vuetify);

import Lodash from 'lodash'
Vue.use(Lodash);

// Test Page
import defaultPage from "./Page/Page1.vue"


if (document.getElementById("defaultPage")) {
    new Vue({
        el: '#defaultPage',
        template: '<defaultPage />',
        components: { defaultPage }
    });
}
