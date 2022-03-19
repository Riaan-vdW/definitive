module.exports = {
    darkMode: 'class',
    content: {
        files: [
            './**/*.html',
            '../Share.Components/**/*.razor',
            '../Share.Components/**/*.razor.cs',
            './**/*.razor',
            './**/*.razor.cs',
            './**/*.cshtml',
            './**/*.cshtml.cs'
        ]
    },
    theme: {
        extend: {},
    },
    plugins: [
        require('@tailwindcss/typography'),
        require('@tailwindcss/forms'),
        require('@tailwindcss/aspect-ratio'),
        require('@tailwindcss/line-clamp')
    ]
}