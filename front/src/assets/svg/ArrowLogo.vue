<script setup lang="ts">
  import { useThemeStore } from '@/stores/theme-store'
  import { storeToRefs } from 'pinia'

  const themeStore = useThemeStore()
  const { darkTheme } = storeToRefs(themeStore)
</script>

<template>
  <svg
    width="24px"
    height="24px"
    viewBox="0 0 1024 1024"
    class="icon"
    version="1.1"
    xmlns="http://www.w3.org/2000/svg"
  >
    <path
      d="M768 903.232l-50.432 56.768L256 512l461.568-448 50.432 56.768L364.928 512z"
      :fill="darkTheme ? '#FFFFFF' : '#000000'"
    />
  </svg>
</template>
