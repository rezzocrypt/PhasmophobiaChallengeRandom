<script setup>
import { ref } from 'vue'

const props = defineProps({
  title: { type: String, required: true },
  items: { type: Array, required: true },
})

const emit = defineEmits(['save', 'close'])

const text = ref(props.items.join('\n'))

const save = () => {
  const cleaned = [
    ...new Set(
      text.value
        .split('\n')
        .map((line) => line.trim())
        .filter((line) => line !== ''),
    ),
  ]
  emit('save', cleaned)
  emit('close')
}
</script>

<template>
  <Teleport to="body">
    <div class="modal-overlay" @click.self="emit('close')">
      <div class="modal" role="dialog" aria-modal="true">
        <h3 class="modal-title">{{ title }}</h3>
        <textarea v-model="text" class="modal-textarea" rows="10" spellcheck="false"></textarea>
        <div class="modal-actions">
          <button type="button" class="btn" @click="emit('close')">Отмена</button>
          <button type="button" class="btn btn-primary" @click="save">Сохранить</button>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<style scoped>
.modal-overlay {
  position: fixed;
  inset: 0;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 16px;
  background: rgba(0, 0, 0, 0.65);
  z-index: 1000;
}

.modal {
  display: flex;
  flex-direction: column;
  gap: 12px;
  width: min(480px, 100%);
  padding: 16px;
  background: var(--color-surface);
  border: 1px solid var(--color-border);
  border-radius: 10px;
  box-shadow: 0 12px 40px rgba(0, 0, 0, 0.5);
}

.modal-title {
  margin: 0;
  font-size: 1.1rem;
  color: var(--color-heading);
}

.modal-textarea {
  width: 100%;
  min-height: 220px;
  resize: vertical;
  padding: 10px;
  font: 1rem/1.4 monospace;
  color: var(--color-text);
  background: var(--color-input);
  border: 1px solid var(--color-border);
  border-radius: 6px;
  outline: none;
}

.modal-textarea:focus {
  border-color: var(--color-accent);
}

.modal-actions {
  display: flex;
  justify-content: flex-end;
  gap: 10px;
}
</style>