/** @type {import('tailwindcss').Config} */
const colors = require('tailwindcss/colors')
const plugin = require('tailwindcss/plugin');

export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx,}",
	"../Timer/**/*.{razor,html,cshtml,cs}"
  ],
  theme: {
    extend: {
      fontFamily: {
          montserrat: ["Montserrat"],
      },
      colors: {
        neutral: colors.teal,
        running: colors.orange,
        paused: colors.yellow,
        completed: colors.red,
        edit: colors.yellow,
        add: colors.lime,
        bg: "#FFF2F8"
      }
    }
  },
  plugins: [],
}
