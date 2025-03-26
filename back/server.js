import express from 'express'
import cors from 'cors'

import fs from 'fs'

const FILEPATH = '../tasks.json'

const app = express()

function readFile(filePath) {
    const data = fs.readFileSync(filePath).toString()

    let jsonData
    try {
        jsonData = JSON.parse(data)
    } catch (err) {
        console.error(err)
        return
    }

    return jsonData
}

function writeFile(filePath, jsonData) {
    fs.writeFileSync(filePath, JSON.stringify(jsonData))
}

app.use(express.json())
app.use(cors())

app.get('/tasks', (req, res) => {
    res.status(200).json(readFile(FILEPATH))
})

app.post('/tasks', (req, res) => {
    const newTask = req.body

    const tasks = readFile(FILEPATH)

    let id
    if (tasks.length === 0) {
        id = 1
    } else {
        id = tasks.at(-1).id + 1
    }

    tasks.push({ ...newTask, id })

    writeFile(FILEPATH, tasks)
    res.status(201).json({ id })
})

app.put('/tasks/:id', (req, res) => {
    const id = parseInt(req.params.id)
    const changeTask = req.body

    const tasks = readFile(FILEPATH)
    const taskIndex = tasks.findIndex(task => task.id === id)

    if (taskIndex !== -1) {
        tasks[taskIndex].title = changeTask.title
        tasks[taskIndex].date = changeTask.date
        tasks[taskIndex].priority = changeTask.priority
        tasks[taskIndex].isActive = changeTask.isActive

        writeFile(FILEPATH, tasks)
        res.status(200).send()
    } else {
        res.status(404).json({ message: 'Task not found' })
    }
})

app.delete('/tasks/:id', (req, res) => {
    const id = parseInt(req.params.id)

    const tasks = readFile(FILEPATH)
    const taskIndex = tasks.findIndex(task => task.id === id)

    if (taskIndex !== -1) {
        tasks.splice(taskIndex, 1)
        writeFile(FILEPATH, tasks)

        res.status(204).send()
    } else {
        res.status(404).json({ message: 'Task not found' })
    }

})

app.listen(3000, () => {
    console.log('Server is running on http://localhost:3000')
})