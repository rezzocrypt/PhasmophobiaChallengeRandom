import { ref } from 'vue'

const THEME_KEY = 'phrandom.theme'
const MODES = ['system', 'light', 'dark']

const stored = localStorage.getItem(THEME_KEY)
const mode = ref(MODES.includes(stored) ? stored : 'system')

const media = window.matchMedia('(prefers-color-scheme: light)')

const apply = () => {
  const current = mode.value === 'system' ? (media.matches ? 'light' : 'dark') : mode.value
  document.documentElement.setAttribute('data-theme', current)
}

const setMode = (value) => {
  if (!MODES.includes(value)) return
  mode.value = value
  localStorage.setItem(THEME_KEY, value)
  apply()
}

apply()

media.addEventListener('change', () => {
  if (mode.value === 'system') apply()
})

export function useTheme() {
  return { mode, setMode, MODES }
}