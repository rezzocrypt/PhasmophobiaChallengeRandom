import { reactive, ref } from 'vue'
import { defaultLists } from '../data/defaults'

const STORAGE_KEY = 'phrandom.params.data'
const FILE_NAME = 'params.data'
const KEYS = ['Maps', 'Difficulty', 'Challenge']

const serialize = (lists) => {
  const obj = {}
  for (const key of KEYS) obj[key] = [...lists[key]]
  return JSON.stringify(obj)
}

const parseData = (text) => {
  const data = JSON.parse(text)
  const lower = {}
  for (const [key, value] of Object.entries(data)) lower[key.toLowerCase()] = value
  return {
    Maps: normalize(lower.maps),
    Difficulty: normalize(lower.difficulty),
    Challenge: normalize(lower.challenge),
  }
}

const normalize = (value) =>
  Array.isArray(value)
    ? value.filter((item) => typeof item === 'string' && item.trim() !== '')
    : []

const randomItem = (items) =>
  items.length > 0 ? items[Math.floor(Math.random() * items.length)] : '?'

const state = reactive({
  lists: {
    Maps: [...defaultLists.Maps],
    Difficulty: [...defaultLists.Difficulty],
    Challenge: [...defaultLists.Challenge],
  },
  selection: {
    Map: '',
    Difficulty: '',
    Challenge: '',
  },
})

const results = ref([])

const persist = () => {
  localStorage.setItem(STORAGE_KEY, serialize(state.lists))
}

const saveList = (key, items) => {
  state.lists[key] = items
  persist()
}

const generate = (count = 5) => {
  results.value = Array.from({ length: count }, () => {
    const pick = (current, items) => (current === '' ? randomItem(items) : current)
    const map = pick(state.selection.Map, sorted(state.lists.Maps))
    const diff = pick(state.selection.Difficulty, sorted(state.lists.Difficulty))
    const chlg = pick(state.selection.Challenge, sorted(state.lists.Challenge))
    return `${map} (${diff}) => ${chlg}`
  })
}

const sorted = (items) => [...items].sort((a, b) => a.localeCompare(b, 'ru'))

const importFile = (file) => {
  return file.text().then((text) => {
    const lists = parseData(text)
    for (const key of KEYS) {
      if (lists[key].length > 0) state.lists[key] = lists[key]
    }
    persist()
  })
}

const exportFile = () => {
  const blob = new Blob([serialize(state.lists)], { type: 'application/json' })
  const url = URL.createObjectURL(blob)
  const link = document.createElement('a')
  link.href = url
  link.download = FILE_NAME
  link.click()
  URL.revokeObjectURL(url)
}

try {
  const cached = localStorage.getItem(STORAGE_KEY)
  if (cached) {
    const lists = parseData(cached)
    for (const key of KEYS) state.lists[key] = lists[key]
  }
} catch {
  // невалидный кэш — оставляем списки по умолчанию
}

export function usePhasmaLists() {
  return {
    state,
    results,
    saveList,
    generate,
    importFile,
    exportFile,
  }
}