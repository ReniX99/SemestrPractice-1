import api from '@/services/axios'
import type { ITask } from '@/types/ITask'
import { defineStore, storeToRefs } from 'pinia'
import { computed, ref } from 'vue'
import { useDateStore } from './date-store'

export const useTasksStore = defineStore(
  'tasks',
  () => {
    const tasks = ref<ITask[]>([])

    const dateStore = useDateStore()
    const { date } = storeToRefs(dateStore)

    const sortOption = ref<string>('Все')

    const currentDateTasks = computed(() => {
      const todayTasks = tasks.value.filter((t) => t.date === date.value)

      switch (sortOption.value) {
        case 'Все':
          return todayTasks.sort((a, b) => Number(b.isActive) - Number(a.isActive))

        case 'Высокий':
          return todayTasks
            .filter((t) => t.priority === 'Высокий')
            .sort((a, b) => Number(b.isActive) - Number(a.isActive))

        case 'Средний':
          return todayTasks
            .filter((t) => t.priority === 'Средний')
            .sort((a, b) => Number(b.isActive) - Number(a.isActive))

        case 'Низкий':
          return todayTasks
            .filter((t) => t.priority === 'Низкий')
            .sort((a, b) => Number(b.isActive) - Number(a.isActive))

        default:
          return todayTasks.sort((a, b) => Number(b.isActive) - Number(a.isActive))
      }
    })

    const countActiveTasks = computed(() => {
      return tasks.value.filter((t) => t.isActive === true && t.date === date.value).length
    })

    async function addTask(newTask: ITask) {
      try {
        const response = await api.post('/task', newTask)
        newTask.id = response.data.id

        tasks.value.push(newTask)
      } catch (err) {
        console.log(err)
      }
    }

    async function editTask(editableTask: ITask) {
      try {
        await api.put(`/task/${editableTask.id}`, editableTask)

        tasks.value[tasks.value.findIndex((t) => t.id === editableTask.id)] = editableTask
      } catch (err) {
        console.log(err)
      }
    }

    async function deleteTask(id: number) {
      try {
        await api.delete(`/task/${id}`)

        tasks.value.splice(
          tasks.value.findIndex((t) => t.id === id),
          1,
        )
      } catch (err) {
        console.log(err)
      }
    }

    async function completeTask(editableTask: ITask) {
      if ((editableTask.isActive = false)) return

      await editTask(editableTask)
      editableTask.isActive = false
    }

    return {
      tasks,
      currentDateTasks,
      countActiveTasks,
      sortOption,
      addTask,
      editTask,
      deleteTask,
      completeTask,
    }
  },
  { persist: true },
)
