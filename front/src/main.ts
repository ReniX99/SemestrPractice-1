import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import pinia from './services/pinia'
import router from './router/router'

createApp(App).use(router).use(pinia).mount('#app')
