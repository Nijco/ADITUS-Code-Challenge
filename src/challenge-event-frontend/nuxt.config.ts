// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2025-07-15',
  devtools: { enabled: true },
  hooks: {
    'pages:extend'(pages) {
      pages.push({
        name: 'home',
        path: '/',
        file: '~/pages/events.vue'
      })
    },
  },
  css: [
    '~/assets/scss/main.scss'
  ],
})
