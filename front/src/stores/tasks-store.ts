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

    const currentDateTasks = computed(() => {
      return tasks.value
        .filter((t) => t.date === date.value)
        .slice()
        .sort((a, b) => Number(b.isActive) - Number(a.isActive))
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

      editableTask.isActive = false
      await editTask(editableTask)
    }

    return {
      tasks,
      currentDateTasks,
      addTask,
      editTask,
      deleteTask,
      completeTask,
    }
  },
  { persist: true },
)
