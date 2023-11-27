module.exports = {
    content: [
        './Views/**/*.cshtml'
    ],
    theme: {
        extend: {
            colors: {
                fore: 'var(--clr-foreground)',
                back: 'var(--clr-background)',
                title: 'var(--clr-title)',
                muted: 'var(--clr-muted)',
                indogrosir: {
                    red: 'var(--clr-indogrosir-red)',
                    blue: 'var(--clr-indogrosir-blue)',
                },
            }
        },
    },
    plugins: [],
}