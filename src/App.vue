<script setup>
import { ref } from 'vue'
import ListSelect from './components/ListSelect.vue'
import ListEditor from './components/ListEditor.vue'
import { usePhasmaLists } from './composables/usePhasmaLists'
import { version } from '../package.json'
import ghostIcon from './assets/ghost.png'

const { state, results, saveList, generate, importFile, exportFile } = usePhasmaLists()

const editorKey = ref(null)
const editorTitles = {
  Maps: 'Редактор карт',
  Difficulty: 'Редактор уровней сложности',
  Challenge: 'Редактор испытаний',
}

const fileInput = ref(null)
const onFileSelected = (event) => {
  const file = event.target.files[0]
  if (file) {
    importFile(file)
      .catch((error) => alert(`Не удалось загрузить файл: ${error.message}`))
      .finally(() => (event.target.value = ''))
  }
}

const generateNew = () => generate(5)
</script>

<template>
  <main class="app">
    <header class="app-header">
      <img :src="ghostIcon" class="app-ghost" alt="ФазмоГен" />
      <h1 class="app-title">ФазмоГен</h1>
    </header>

    <section class="panel">
      <div class="rows">
        <ListSelect
          v-for="key in ['Maps', 'Difficulty', 'Challenge']"
          :key="key"
          :label="{ Maps: 'Карта', Difficulty: 'Сложность', Challenge: 'Задание' }[key]"
          :items="state.lists[key]"
          :model-value="state.selection[key]"
          @update:model-value="state.selection[key] = $event"
          @edit="editorKey = key"
        />
      </div>

      <div class="random-row">
        <button type="button" class="btn btn-random" @click="generateNew">
          <img :src="ghostIcon" alt="" />
          <span>Рандом</span>
        </button>
        <div class="file-actions">
          <button type="button" class="btn" @click="fileInput.click()">Загрузить params.data</button>
          <button type="button" class="btn" @click="exportFile">Сохранить params.data</button>
          <input
            ref="fileInput"
            type="file"
            accept=".data,.json,application/json"
            class="hidden-input"
            @change="onFileSelected"
          />
        </div>
      </div>

      <ol v-if="results.length" class="results">
        <li v-for="(line, index) in results" :key="index" class="results-item">{{ line }}</li>
      </ol>
      <p v-else class="results-empty">Нажми «Рандом», чтобы сгенерировать задания</p>
    </section>

    <ListEditor
      v-if="editorKey"
      :title="editorTitles[editorKey]"
      :items="state.lists[editorKey]"
      @save="saveList(editorKey, $event)"
      @close="editorKey = null"
    />
  <footer class="app-version">v{{ version }}</footer>
  </main>
</template>

<style scoped>
.app {
  max-width: 640px;
  margin: 0 auto;
  padding: 24px 16px;
  display: flex;
  flex-direction: column;
  gap: 16px;
}

.app-header {
  display: flex;
  align-items: center;
  gap: 12px;
}

.app-ghost {
  width: 48px;
  height: 48px;
  border-radius: 8px;
}

.app-title {
  margin: 0;
  font-size: 1.8rem;
  color: var(--color-heading);
}

.panel {
  display: flex;
  flex-direction: column;
  gap: 16px;
  padding: 16px;
  background: var(--color-surface);
  border: 1px solid var(--color-border);
  border-radius: 10px;
}

.rows {
  display: flex;
  flex-direction: column;
  gap: 12px;
}

.random-row {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 10px;
  flex-wrap: wrap;
}

.btn-random {
  gap: 8px;
  font-size: 1.1rem;
}

.btn-random img {
  width: 28px;
  height: 28px;
}

.file-actions {
  display: flex;
  gap: 8px;
  flex-wrap: wrap;
}

.hidden-input {
  display: none;
}

.results {
  margin: 0;
  padding: 0;
  list-style: none;
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.results-item {
  padding: 8px 12px;
  font-size: 1.05rem;
  color: var(--color-text);
  background: var(--color-input);
  border: 1px solid var(--color-border);
  border-radius: 6px;
}

.results-empty {
  margin: 0;
  padding: 12px;
  text-align: center;
  color: var(--color-muted);
  border: 1px dashed var(--color-border);
  border-radius: 6px;
}
.app-version {
  position: fixed;
  left: 12px;
  bottom: 8px;
  font-size: 0.75rem;
  color: var(--color-muted);
  user-select: none;
}
</style>