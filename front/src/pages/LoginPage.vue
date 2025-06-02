<script setup lang="ts">
  import api from '@/services/axios'
  import { ref } from 'vue'
  import { useRouter } from 'vue-router'

  const form = ref({
    email: '',
    password: '',
  })

  const router = useRouter()
  const handleForm = async () => {
    try {
      if (form.value.email === '' || form.value.password === '') return

      await api.post('auth/login', form.value)

      router.push({ name: 'MainPage' })
    } catch (err) {
      console.log(err)
    }
  }
</script>

<template>
  <main class="min-h-screen bg-[#F3F4F6] py-[48px]">
    <div
      class="mx-auto w-[420px] rounded-[8px] bg-white px-[24px] py-[32px] shadow-[0_2px_6px_rgba(0,0,0,0.1)]"
    >
      <h1 class="mb-[48px] text-center text-[24px] font-medium">Вход</h1>
      <form class="flex flex-col" @submit.prevent="handleForm">
        <div class="mb-[44px] flex flex-col gap-[32px]">
          <div class="flex flex-col gap-[10px]">
            <label>Почта</label>
            <input
              v-model="form.email"
              type="email"
              class="rounded-[4px] border border-[#727272] px-[12px] py-[8px]"
            />
          </div>
          <div class="flex flex-col gap-[10px]">
            <label>Пароль</label>
            <input
              v-model="form.password"
              type="password"
              class="rounded-[4px] border border-[#727272] px-[12px] py-[8px]"
            />
          </div>
        </div>
        <button
          class="mb-[24px] w-[264px] cursor-pointer self-center rounded-[6px] bg-[#2d2d2d] py-[12px] text-[17px] font-medium text-white"
          type="submit"
        >
          Войти
        </button>
        <router-link :to="{ name: 'RegisterPage' }">
          <p class="cursor-pointer underline">Зарегистрироваться</p>
        </router-link>
      </form>
    </div>
  </main>
</template>
