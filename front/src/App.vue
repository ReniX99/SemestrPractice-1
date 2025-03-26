<script setup lang="ts">
  import { onMounted } from 'vue'
  import TaskList from './components/TaskList.vue'
  import ModalWindow from './components/ModalWindow.vue'
  import ArrowButton from './components/ArrowButton.vue'
  import { useModalStore } from './stores/modal-store'
  import { useTasksStore } from './stores/tasks-store'
  import api from './services/axios'
  import { storeToRefs } from 'pinia'
  import { useThemeStore } from './stores/theme-store'
  import DateInput from './components/DateInput.vue'
  import { useDateStore } from './stores/date-store'

  const tasksStore = useTasksStore()
  const { tasks } = storeToRefs(tasksStore)

  const modalStore = useModalStore()
  const { isOpen: isOpenModal } = storeToRefs(modalStore)

  const themeStore = useThemeStore()
  const { darkTheme } = storeToRefs(themeStore)

  const dateStore = useDateStore()
  const { date } = storeToRefs(dateStore)

  onMounted(async () => {
    if (tasks.value.length === 0) {
      try {
        const response = await api.get('/tasks')
        tasks.value = response.data
      } catch (err) {
        console.log(err)
      }
    }
    const currentDate = new Date().toISOString().split('T')[0]
    date.value = currentDate
  })
</script>

<template>
  <main class="min-h-screen py-[40px]" :class="[darkTheme ? 'bg-[#292727]' : 'bg-white']">
    <div class="mx-auto max-w-[1200px] px-[48px] pb-[40px] sm:px-[32px]">
      <h1
        class="font-roboto mb-[60px] text-center text-3xl"
        :class="[darkTheme ? 'text-white' : 'text-[#292727]']"
      >
        Самый НЕОБЫЧНЫЙ To-Do List
      </h1>
      <button
        @click="themeStore.toggleTheme()"
        class="absolute top-[40px] right-[60px] cursor-pointer rounded-[8px] px-[12px] py-[8px] opacity-0 lg:opacity-100"
        :class="[darkTheme ? 'bg-white text-[#292727]' : 'bg-[#292727] text-white']"
      >
        Сменить тему
      </button>
      <section class="relative mb-[40px] flex flex-col items-center gap-[30px]">
        <div class="mx-auto flex items-center gap-[20px]">
          <ArrowButton @click="dateStore.changeDate(-1)" />
          <DateInput v-model:date="date" />
          <ArrowButton class="rotate-180" @click="dateStore.changeDate(1)" />
        </div>
        <button
          @click="modalStore.open('add')"
          class="cursor-pointer rounded-[8px] bg-[#1ce522] px-[12px] py-[8px] text-white transition duration-300 hover:scale-103 active:bg-[#12a617] md:absolute md:left-0"
        >
          Добавить задачу
        </button>
      </section>
      <TaskList />
      <Transition name="modal">
        <ModalWindow v-if="isOpenModal" />
      </Transition>
    </div>
  </main>
</template>

<style>
  .modal-enter-active,
  .modal-leave-active {
    transition: opacity 0.3s ease;
  }

  .modal-enter-from,
  .modal-leave-to {
    opacity: 0;
  }

  input[type='date']::-webkit-calendar-picker-indicator {
    filter: invert(1) /* Инвертировать цвета */ brightness(100%) saturate(0%);
  }
</style>
