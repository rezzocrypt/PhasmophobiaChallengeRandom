<script setup>
import { computed } from 'vue'
import editIcon from '../assets/edit.png'

const props = defineProps({
  label: { type: String, required: true },
  items: { type: Array, required: true },
  modelValue: { type: String, default: '' },
})

const emit = defineEmits(['update:modelValue', 'edit'])

const uniqueItems = computed(() =>
  [...new Set([...props.items].sort((a, b) => a.localeCompare(b, 'ru')))],
)
</script>

<template>
  <div class="row">
    <label class="row-label" :for="`select-${label}`">{{ label }}</label>
    <select
      :id="`select-${label}`"
      class="row-select"
      :value="modelValue"
      @change="emit('update:modelValue', $event.target.value)"
    >
      <option value="">Случайно</option>
      <option v-for="item in uniqueItems" :key="item" :value="item">{{ item }}</option>
    </select>
    <button type="button" class="row-edit" :title="`Редактировать список: ${label}`" @click="emit('edit')">
      <img :src="editIcon" alt="Редактировать" />
    </button>
  </div>
</template>

<style scoped>
.row {
  display: grid;
  grid-template-columns: 130px 1fr 40px;
  align-items: center;
  gap: 10px;
}

.row-label {
  font-size: 1rem;
  color: var(--color-text);
}

.row-select {
  width: 100%;
  padding: 8px 10px;
  font-size: 1rem;
  color: var(--color-text);
  background: var(--color-input);
  border: 1px solid var(--color-border);
  border-radius: 6px;
  outline: none;
}

.row-select:focus {
  border-color: var(--color-accent);
}

.row-edit {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 40px;
  background: var(--color-input);
  border: 1px solid var(--color-border);
  border-radius: 6px;
  cursor: pointer;
}

.row-edit:hover {
  border-color: var(--color-accent);
}

.row-edit img {
  width: 20px;
  height: 20px;
}
</style>