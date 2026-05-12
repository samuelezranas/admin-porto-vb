# Admin Panel UI Layout & Visual Guide

## Application Window Layout

```
┌────────────────────────────────────────────────────────────────────────────────┐
│  🟣 Website Admin Panel                    🔄 Refresh │ 🔗 Go to Website │ 🚪 Logout │
├────────────────────────────────────────────────────────────────────────────────┤
│ [Dashboard] [About] [Certification] [Portfolio] [Contact]                       │
├────────────────────────────────────────────────────────────────────────────────┤
│                                                                                  │
│  ┌─────────────────────────────────────────────────────────────────────────┐   │
│  │                                                                         │   │
│  │  Content Area (Changes Based on Selected Tab)                          │   │
│  │                                                                         │   │
│  │  Dashboard:     Statistics cards                                        │   │
│  │  About:         Profile editor                                          │   │
│  │  Certification: Certificate list                                        │   │
│  │  Portfolio:     Project cards                                           │   │
│  │  Contact:       Message inbox                                           │   │
│  │                                                                         │   │
│  └─────────────────────────────────────────────────────────────────────────┘   │
│                                                                                  │
└────────────────────────────────────────────────────────────────────────────────┘
```

---

## Header Section

```
┌────────────────────────────────────────────────────────────────────────────────┐
│                                                                                  │
│  🟣 Website Admin Panel                      🔄 Refresh  🔗 Go to Website  🚪 Logout │
│                                                                                  │
└────────────────────────────────────────────────────────────────────────────────┘

Color: #190C23 (Dark Purple)
Height: 90px
Elements:
  - Title: "Website Admin Panel" (24pt, Bold, White)
  - Buttons with purple borders (#9650B6)
  - Right-aligned action buttons
```

---

## Navigation Tabs

```
┌────────────────────────────────────────────────────────────────────────────────┐
│                                                                                  │
│  [Dashboard]  [About]  [Certification]  [Portfolio]  [Contact]                 │
│    ┌────┐    ┌──────┐    ┌────────────┐   ┌───────────┐   ┌─────────┐         │
│    │2px │    │2px   │    │2px Border  │   │2px Border │   │2px Bdr  │         │
│    │Bdr │    │Bdr   │    │(Purple)    │   │(Purple)   │   │(Purple) │         │
│    └────┘    └──────┘    └────────────┘   └───────────┘   └─────────┘         │
│                                                                                  │
└────────────────────────────────────────────────────────────────────────────────┘

Color: #190C23 (Dark Purple)
Height: 60px
Button Style:
  - Transparent background
  - 2px purple border (#9650B6)
  - White text (Bold, 11pt)
  - Cursor: Hand
  - Active: #643C64 (darker purple)
```

---

## Dashboard Content Area

```
┌────────────────────────────────────────────────────────────────────────────────┐
│                                                                                  │
│  📊 Google Analytics                                                            │
│                                                                                  │
│  ┌──────────────────┐  ┌──────────────────┐  ┌──────────────────────┐         │
│  │ About Photos     │  │ Certifications   │  │ Portfolio Projects   │         │
│  │                  │  │                  │  │                      │         │
│  │       3          │  │        16        │  │         10           │         │
│  └──────────────────┘  └──────────────────┘  └──────────────────────┘         │
│  ┌──────────────────────────────────────────────────────────────────┐         │
│  │                                                                   │         │
│  │ ⚠️ GA4_PROPERTY_ID belum ditur di environment Vercel.            │         │
│  │                                                                   │         │
│  └──────────────────────────────────────────────────────────────────┘         │
│                                                                                  │
└────────────────────────────────────────────────────────────────────────────────┘

Statistics Card Style:
  - Size: 260x120px
  - Background: #322832
  - Border: 1px solid border
  - Left border accent: 2px purple (#9650B6)
  - Title: 11pt, gray text
  - Value: 32pt, bold, white text

Alert Box Style:
  - Background: #503C3C
  - Text: Yellow (#FFFF00)
  - Padding: 10px
  - Font: 11pt
```

---

## About Section

```
┌────────────────────────────────────────────────────────────────────────────────┐
│                                                                                  │
│  About Settings                                                                 │
│                                                                                  │
│  Title:                                                                          │
│  ┌──────────────────────────────────────────────────────────────────┐          │
│  │ Hello, everyone. This is Samuel Ezra.                            │          │
│  └──────────────────────────────────────────────────────────────────┘          │
│                                                                                  │
│  Description:                                                                    │
│  ┌──────────────────────────────────────────────────────────────────┐          │
│  │ I am an Information Technology undergraduate focused on software │          │
│  │ engineering, interface design, and visual storytelling...         │          │
│  │                                                                   │          │
│  │                                                        ⋮          │          │
│  └──────────────────────────────────────────────────────────────────┘          │
│                                                                                  │
│  Social Link:                                                                    │
│  ┌──────────────────────────────────────────────────────────────────┐          │
│  │ https://drive.google.com/                                         │          │
│  └──────────────────────────────────────────────────────────────────┘          │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────┐          │
│  │              💾 Simpan About                                      │          │
│  └──────────────────────────────────────────────────────────────────┘          │
│                                                                                  │
└────────────────────────────────────────────────────────────────────────────────┘

Input Field Style:
  - Background: #322832
  - Text: White
  - Border: 1px solid
  - Single-line: Height 35px
  - Multi-line: Height 120px

Button Style:
  - Background: #9650B6
  - Text: White (Bold, 12pt)
  - Full width: 500px
  - Height: 45px
  - Cursor: Hand
```

---

## Certification List

```
┌────────────────────────────────────────────────────────────────────────────────┐
│                                                                                  │
│  📜 List Sertifikat                                              [➕ Tambah]   │
│  Gunakan tombol Tambah untuk membuat data sertifikat baru.                     │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────────────┐  │
│  │ Pengenalan ke Logika Pemrograman (Programming Logic 101)              │  │  │
│  │ Dicoding Indonesia · 2024                                              │  │  │
│  │ Order: 0                                                               │  │  │
│  │ [⬆ Up] [⬇ Down]                                           [Active]  │  │  │
│  └──────────────────────────────────────────────────────────────────────────┘  │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────────────┐  │
│  │ Belajar Dasar Visualisasi Data                                       │  │  │
│  │ Dicoding Academy · 2024                                              │  │  │
│  │ Order: 0                                                               │  │  │
│  │ [⬆ Up] [⬇ Down]                                           [Active]  │  │  │
│  └──────────────────────────────────────────────────────────────────────────┘  │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────────────┐  │
│  │ Belajar Dasar AI                                                     │  │  │
│  │ Dicoding Academy · 2024                                              │  │  │
│  │ Order: 0                                                               │  │  │
│  │ [⬆ Up] [⬇ Down]                                           [Active]  │  │  │
│  └──────────────────────────────────────────────────────────────────────────┘  │
│                                                                                  │
└────────────────────────────────────────────────────────────────────────────────┘

Certificate Card Style:
  - Size: 1120x180px
  - Background: #322832
  - Left border: 2px purple (#9650B6)
  - Title: 13pt, bold, white
  - Details: 10pt, gray
  - Button size: 80x35px
  - Status badge: 80x25px, colored background

Add Button:
  - Background: #64C864 (Green)
  - Text: ➕ Tambah
  - Position: Top right
```

---

## Portfolio Projects

```
┌────────────────────────────────────────────────────────────────────────────────┐
│                                                                                  │
│  💼 Portfolio Projects                                             [➕ Tambah]  │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────────────┐  │
│  │ Project Title                                                        │  │  │
│  │ Description of the project goes here...                             │  │  │
│  │ [✏️ Edit] [🗑️ Delete]                                              │  │  │
│  └──────────────────────────────────────────────────────────────────────────┘  │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────────────┐  │
│  │ Another Project                                                    │  │  │
│  │ Project description and details...                                 │  │  │
│  │ [✏️ Edit] [🗑️ Delete]                                              │  │  │
│  └──────────────────────────────────────────────────────────────────────────┘  │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────────────┐  │
│  │ Third Project                                                      │  │  │
│  │ More project information here...                                   │  │  │
│  │ [✏️ Edit] [🗑️ Delete]                                              │  │  │
│  └──────────────────────────────────────────────────────────────────────────┘  │
│                                                                                  │
└────────────────────────────────────────────────────────────────────────────────┘

Project Card Style:
  - Size: 1120x150px
  - Background: #322832
  - Left border: 2px purple (#9650B6)
  - Title: 13pt, bold, white
  - Description: 10pt, gray
  - Button size: 80x35px

Edit Button: Purple border
Delete Button: Red background
```

---

## Contact Messages

```
┌────────────────────────────────────────────────────────────────────────────────┐
│                                                                                  │
│  💬 Messages                                                                    │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────────────┐  │
│  │ From: John Doe                                                        │  │  │
│  │ Subject: Inquiry about collaboration                                  │  │  │
│  │ Hi Samuel, I'm interested in working together on a project...         │  │  │
│  │ [↩️ Reply]                                                            │  │  │
│  └──────────────────────────────────────────────────────────────────────────┘  │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────────────┐  │
│  │ From: Jane Smith                                                      │  │  │
│  │ Subject: Great work on your portfolio                                 │  │  │
│  │ I love your design work. Would love to connect...                     │  │  │
│  │ [↩️ Reply]                                                            │  │  │
│  └──────────────────────────────────────────────────────────────────────────┘  │
│                                                                                  │
│  ┌──────────────────────────────────────────────────────────────────────────┐  │
│  │ From: Alex Johnson                                                    │  │  │
│  │ Subject: Job opportunity                                              │  │  │
│  │ We have an exciting role that matches your skills perfectly...        │  │  │
│  │ [↩️ Reply]                                                            │  │  │
│  └──────────────────────────────────────────────────────────────────────────┘  │
│                                                                                  │
└────────────────────────────────────────────────────────────────────────────────┘

Message Card Style:
  - Size: 1120x150px
  - Background: #322832
  - Left border: 2px purple (#9650B6)
  - Sender: 11pt, bold, white
  - Subject: 10pt, yellow
  - Message: 10pt, gray
  - Reply button: 80x25px
```

---

## Color Palette Reference

```
┌──────────────────────────────────────────────────────┐
│ COLOR PALETTE                                        │
├──────────────────────────────────────────────────────┤
│                                                      │
│ 🟣 #190C23 - Dark Purple (Main Background)          │
│ 🟣 #322832 - Medium Purple (Cards/Panels)           │
│ 🟣 #503C3C - Light Purple (Alert boxes)             │
│ 🟣 #9650B6 - Purple Accent (Borders/Buttons)        │
│ 🟣 #643C64 - Dark Purple Accent (Hover/Active)      │
│                                                      │
│ ⚪ #FFFFFF - White (Primary Text)                    │
│ ⚫ #808080 - Gray (Secondary Text)                   │
│ 🟡 #FFFF00 - Yellow (Warnings)                       │
│ 🟢 #64C864 - Green (Success/Active)                  │
│ 🔴 #C86464 - Red (Error/Inactive)                    │
│                                                      │
└──────────────────────────────────────────────────────┘
```

---

## Typography Guide

```
┌────────────────────────────────────────┐
│ TYPOGRAPHY                             │
├────────────────────────────────────────┤
│                                        │
│ Font Family: Segoe UI                  │
│                                        │
│ Page Title:     24pt Bold White        │
│ Section Title:  18-20pt Bold White     │
│ Card Title:     13pt Bold White        │
│ Label:          11pt White             │
│ Secondary Text: 10pt Gray              │
│ Small Text:      9pt Gray              │
│                                        │
│ Button Text: 9-12pt Bold White         │
│                                        │
└────────────────────────────────────────┘
```

---

## Responsive Spacing

```
┌─────────────────────────────────────────┐
│ SPACING GUIDE                           │
├─────────────────────────────────────────┤
│                                         │
│ Page Margin:        40px (all sides)    │
│ Section Spacing:    40px (vertical)     │
│ Card Spacing:       10-20px             │
│ Button Spacing:     10px                │
│ Inner Padding:      15px (cards)        │
│ Text Padding:       10px                │
│                                         │
│ Component Sizes:                        │
│ ├─ Large Card:      1120x180px          │
│ ├─ Stat Card:        260x120px          │
│ ├─ Button:           80-150x35px        │
│ └─ Badge:            80x25px            │
│                                         │
└─────────────────────────────────────────┘
```

---

## Interactive States

```
Button States:
├─ Default:   Transparent bg, purple border
├─ Hover:     Slight darkening, hand cursor
├─ Pressed:   Darker background
└─ Disabled:  Grayed out

Input States:
├─ Empty:     Purple border
├─ Focused:   Lighter border
├─ Filled:    White text visible
└─ Error:     Red border

Card States:
├─ Inactive:  Normal styling
├─ Active:    Highlighted border
└─ Hover:     Slight elevation effect
```

---

## Screen Resolutions

### Recommended
- **1280x700px** - Minimum (Current)
- **1400x800px** - Optimal
- **1920x1080px** - Full HD
- **2560x1440px** - 2K

### Scaling
Application scales with DPI settings:
- 100% DPI - 1280x700px window
- 125% DPI - Scaled proportionally
- 150% DPI - Adjusted for larger displays
- 200% DPI - Accessible large display

---

This visual guide provides a complete reference for the admin panel's appearance, layout, colors, and styling!
