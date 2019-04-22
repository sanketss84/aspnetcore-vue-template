Vuetify is the heart of the VueJS codebase , it enables us to create code faster taking care of the styling needs.
While using it you get the best of material principles and you dont need any extra css framework like bootstrap.

For icons we can use material icons or font awesome both are supported.

**Vuetify Structure**

The v-container can be used for a center focused page, or given the fluid prop to extend its full width. v-layout is used for separating sections and contains the v-flex. The structure of your layout will be as follows, v-container » v-layout » v-flex. Each part of the grid chain is a flex-box element. The final, v-flex, automatically sets its children to have flex: 1 1 auto.

For convenience reasons, these components automatically transform attributes into classes. Allowing you to write ```<v-layout pa-3 mb-2></v-layout>``` instead of ```<v-layout class="pa-3 mb-2"></v-layout>```.


```
<template>
    <div id="defaultPage">        
        <v-app>
            <v-container>                
               
            </v-container>
        </v-app>
    </div>
</template>
```

**What Vuetify offers and key things to remember**

Framework Options

- [12 column Grid System](https://vuetifyjs.com/en/framework/grid)
- [Grid List](https://vuetifyjs.com/en/framework/grid-lists)

Application Layout

- [Aspect ratios](https://vuetifyjs.com/en/framework/aspect-ratios)
- [Breakpoints](https://vuetifyjs.com/en/framework/breakpoints)
- [Material Component Framework](https://vuetifyjs.com/en/framework/default-markup)

Style And Themes

- [Material color palette](https://vuetifyjs.com/en/framework/colors)
- [Installing Icons](https://vuetifyjs.com/en/framework/icons)
  - [Icons - Material Design](https://material.io/tools/icons/?style=baseline)
- [Application typography](https://vuetifyjs.com/en/framework/typography)


Helper Classes

- [Display helpers](https://vuetifyjs.com/en/framework/display)
- [Spacing helpers](https://vuetifyjs.com/en/framework/spacing)
- [Alignment helpers](https://vuetifyjs.com/en/framework/alignment)
- [Elevation helpers](https://vuetifyjs.com/en/framework/elevation)


UI Components
- [Cards](https://vuetifyjs.com/en/components/cards)
- [List Component](https://vuetifyjs.com/en/components/lists)
- [Form Component](https://vuetifyjs.com/en/components/forms)


  