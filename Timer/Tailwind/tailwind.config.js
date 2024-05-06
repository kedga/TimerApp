/** @type {import('tailwindcss').Config} */
const colors = require('tailwindcss/colors')
const plugin = require('tailwindcss/plugin');

export default {
  content: ["../**/*.{html,js,razor}"],
  theme: {
    extend: {
      colors: {
        neutral: colors.slate,
        running: colors.orange,
        paused: colors.yellow,
        completed: colors.red,
      }
    }
  },
  plugins: [],
}
