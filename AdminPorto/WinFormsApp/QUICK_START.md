# Quick Start Guide - Website Admin Panel Desktop

## Installation & Setup

### 1. Prerequisites
- Windows 7 or higher
- .NET 6.0 or later
- Internet connection

### 2. First Launch
1. Run the application executable
2. Application automatically creates necessary folders in:
   - `C:\Users\[YourUsername]\AppData\Roaming\AdminPanel\`
3. Application is ready to use immediately

### 3. Main Dashboard
When you first open the app, you'll see:
- **📊 Google Analytics**: Your website's visitor statistics
- **About Photos**: Count of profile photos (currently 3)
- **Certifications**: Number of certifications (currently 16)
- **Portfolio Projects**: Number of projects displayed (currently 10)
- **Messages**: Contact form submissions received (currently 3)

## Navigation Guide

### 🎯 Dashboard Tab
- Overview of all website statistics
- Quick access to key metrics
- System alerts and warnings

### 👤 About Tab
Edit your profile information:
1. **Title**: Your greeting message
   - Default: "Hello, everyone. This is Samuel Ezra."
2. **Description**: Your professional bio
   - Full description of your background and skills
3. **Social Link**: Link to your Google Drive or other profile
   - Default: https://drive.google.com/

**To Save Changes:**
- Edit the fields
- Click "💾 Simpan About" button
- Wait for success confirmation

### 🎓 Certification Tab
Manage your certifications and certificates:

**Adding New Certificate:**
1. Click "➕ Tambah" button
2. Enter certificate details:
   - Certificate Name/Title
   - Organization/Issuer
   - Year Earned
3. Click "Simpan" to save

**Reordering Certificates:**
- Click "⬆ Up" to move up in the list
- Click "⬇ Down" to move down in the list
- Order affects display position on website

**Certificate Status:**
- Green "Active" badge = Visible on website
- Click badge to toggle visibility

**Sample Certificates Shown:**
- Pengenalan ke Logika Pemrograman (Programming Logic 101)
- Belajar Dasar Visualisasi Data
- Belajar Dasar AI
- Belajar Dasar Structured Query Language (SQL)

### 💼 Portfolio Tab
Manage your project portfolio:

**Adding New Project:**
1. Click "➕ Tambah" button
2. Fill in project details:
   - Project Title
   - Project Description
   - Project Link/GitHub URL
   - Project Image
3. Set display order
4. Click "Simpan" to save

**Editing Projects:**
- Click "✏️ Edit" on any project card
- Modify details as needed
- Save changes

**Deleting Projects:**
- Click "🗑️ Delete" button
- Confirm deletion
- Project removed from portfolio

### 👥 About Photos Tab
Manage your profile and about section photos:

**Features:**
- Upload new photos
- Reorder photos (up/down)
- Toggle photo visibility (Active/Inactive)
- View photo preview
- Delete unwanted photos

### 💬 Contact Tab
View and manage visitor messages:

**Available Actions:**
- View message sender name
- Read message subject
- Read full message content
- Reply to visitor
- Archive or delete messages
- Mark as read/unread

**Sample Messages:**
- Shows sender names and subjects
- Full message preview
- Quick action buttons

## Top Menu Actions

### 🔄 Refresh
- Reloads current page data
- Syncs with server
- Updates statistics
- Useful after making changes

### 🔗 Go to Website
- Opens your website in default browser
- URL: https://www.samuelezranas.codes/
- Verify changes published on live site

### 🚪 Logout
- Closes the application
- Saves any pending changes
- Requires confirmation before exit

## Data Management

### Local Storage
Your data is stored locally for offline access:
- **Location**: `C:\Users\[YourUsername]\AppData\Roaming\AdminPanel\`
- **Files**:
  - `certifications.json`
  - `about.json`
  - `messages.json`
  - `portfolios.json`

### Backup
- Keep automatic local backups
- Backup folder created automatically
- Useful for data recovery

### Sync with Server
Changes are automatically synced to:
- API Endpoint: `https://www.samuelezranas.codes/api`
- Website updates in real-time after save
- Check live site with "Go to Website" button

## Color Theme

The application uses a professional dark purple theme:
- **Dark Background**: Reduces eye strain
- **Purple Accents**: Matches your website design
- **Green Status**: Active/Good status
- **Red Status**: Inactive/Needs attention
- **Yellow Warnings**: Important alerts

## Tips & Best Practices

### 1. Organization
- Keep certificates in chronological order (newest first)
- Order portfolio projects by importance
- Arrange photos in logical sequence

### 2. Descriptions
- Use clear, concise descriptions for projects
- Include relevant skills and technologies
- Add direct links to live projects or GitHub

### 3. Regular Updates
- Refresh data daily to sync changes
- Review contact messages regularly
- Update portfolio with new projects

### 4. Data Safety
- All changes are saved locally
- Server sync happens automatically
- Keep API credentials secure
- Backup important data periodically

### 5. Troubleshooting
- **Can't save?** Check internet connection
- **Data not appearing?** Click Refresh button
- **Wrong information?** Edit and save again
- **Error messages?** Try restarting application

## Common Tasks

### Task: Add a New Certificate
1. Go to **Certification** tab
2. Click **➕ Tambah** button
3. Enter certificate name, organization, year
4. Click **Simpan**
5. New certificate added to list

### Task: Reorder Certificates
1. Go to **Certification** tab
2. Find certificate to move
3. Click **⬆ Up** or **⬇ Down**
4. Changes saved automatically
5. Refresh website to see changes

### Task: Update Profile Bio
1. Go to **About** tab
2. Edit **Description** field
3. Update text as needed
4. Click **💾 Simpan About**
5. Changes appear on website

### Task: Add Portfolio Project
1. Go to **Portfolio** tab
2. Click **➕ Tambah**
3. Enter project details
4. Upload project image
5. Click **Simpan**
6. Project visible on portfolio

### Task: Reply to Message
1. Go to **Contact** tab
2. Find message to reply
3. Click **↩️ Reply**
4. Type response message
5. Click **Send**
6. Sender receives your reply

## Keyboard Shortcuts

While not implemented in v1.0, future versions will include:
- `Ctrl+S` - Save current changes
- `Ctrl+R` - Refresh page
- `Ctrl+W` - Go to website
- `Alt+F4` - Exit application
- `Ctrl+Z` - Undo last action

## Support & Help

### Website
- Main: https://www.samuelezranas.codes/
- Web Admin: https://www.samuelezranas.codes/admin

### Need Help?
- Check this guide for common tasks
- Review error messages carefully
- Ensure internet connection is stable
- Restart application if issues persist

### Report Issues
- Document what went wrong
- Note any error messages
- Include steps to reproduce
- Contact through website

## What's Different from Web Admin Panel

### Desktop Version Advantages
- ✅ Works offline (with cached data)
- ✅ Faster performance
- ✅ No login required
- ✅ Instant UI responses
- ✅ Local data backup
- ✅ Professional desktop integration

### Web Version Advantages
- ✅ Access from anywhere
- ✅ Multi-device support
- ✅ Cloud-based backup
- ✅ Real-time collaboration features

## Version Information

- **Version**: 1.0.0
- **Release Date**: 2024
- **Status**: Production Ready
- **Last Updated**: 2024
- **Platform**: Windows Desktop (.NET 6.0+)

---

**Happy Managing!** 🚀

For more information, visit https://www.samuelezranas.codes/
