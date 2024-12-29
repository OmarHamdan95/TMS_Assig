/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./src/**/*.{html,ts}",
        "./src/app/**/*.html",
        "./src/assets/scss/tailwind.scss",
        // "./node_modules/apexcharts/**/*",
    ],
    darkMode: ['class', '[data-mode="dark"]'],
    theme: {
        container: {
            center: true,
            padding: '1.5rem',
        },
        extend: {
            fontFamily: {
                cerebri: ["Droid Arabic Kufi", "sans-serif"],
            },
            colors: {
                transperent: "transperent",
                current: "currentColor",
                muted: "#94989a",
                white: "#ffffff",
                light: "#e2e6eb",
                black: "#323a46",
                purple: "#CBA344",
                success: "#50cd89",
                danger: "#f1416c",
                warning: "#ffc700",
                info: "#009ef7",
                dark: "#151515",
                darklight: "#1F1F1F",
                darkborder: "#343331",
                darkmuted: "#767273",
            },

        },
    },
    plugins: [
        require("@tailwindcss/forms")({
            strategy: "base", // only generate global styles
        }),
        require("tailwind-scrollbar"),
        require('./plugins/layouts/layouts'),
        require('./plugins/layouts/sidebar'),
        require('./plugins/card'),
        require('./plugins/buttons'),
        require('./plugins/forms'),
        require('./plugins/tables'),
        require('./plugins/plugins/flatpicker'),
        require('./plugins/plugins/apexchart'),
    ],
}
