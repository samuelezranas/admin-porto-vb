# Website Admin Panel - Desktop Application

A professional desktop admin panel application built with VB.NET Windows Forms for managing your portfolio website (samuelezranas.codes).

## Features

### 📊 Dashboard
- **Google Analytics Integration**: View website statistics and metrics
- **Quick Stats**: Display counts for:
  - About Photos
  - Certifications
  - Portfolio Projects
  - Contact Messages
- **System Alerts**: Important notifications and warnings

### 👤 About Management
- **Personal Information**: Manage your profile title and bio
- **Description Editing**: Rich text area for detailed bio information
- **Social Links**: Manage social media and profile links
- **Real-time Save**: Immediately sync changes to your website

### 🎓 Certification Management
- **List View**: Browse all certifications with details
- **Add Certificates**: Create new certification entries
  - Title/Name
  - Organization
  - Year
  - Order/Priority
- **Reorder**: Move certifications up or down in display order
- **Status Badge**: Active/Inactive status indicators
- **Edit & Delete**: Modify or remove certifications

### 💼 Portfolio Management
- **Project List**: View all portfolio projects
- **Create Projects**: Add new portfolio entries with:
  - Project Title
  - Description
  - Project Link
  - Featured Image
  - Order
- **Edit Projects**: Modify project details
- **Delete Projects**: Remove projects from your portfolio
- **Order Management**: Arrange projects by priority

### 👥 About Photos
- **Photo Gallery**: Manage profile photos
- **Upload Images**: Add photos directly from your computer
- **Reorder Photos**: Arrange photos in display order
- **Status Control**: Toggle photos active/inactive

### 💬 Contact Messages
- **Message Inbox**: View all contact form submissions
- **Message Details**: See sender information and full message
- **Reply**: Send responses to visitors
- **Archive**: Keep track of handled inquiries

## Design Theme

The application features a modern dark theme with purple accents, matching your website design:
- **Primary Color**: Dark Purple (#190C23)
- **Accent Color**: Purple (#9650B6)
- **Text Color**: White (#FFFFFF)
- **Modern UI**: Clean, minimalist design with rounded borders
- **Responsive Controls**: Buttons with hover effects and proper spacing

## Technical Architecture

### Project Structure
```
WinFormsApp1/
├── Form1.vb                 # Main application form
├── Form1.Designer.vb        # UI designer
├── Models/
│   ├── CertificationModel.vb
│   ├── PortfolioModel.vb
│   ├── AboutModel.vb
│   └── MessageModel.vb
└── Services/
    ├── ApiService.vb        # API integration
    └── LocalStorageService.vb # Local data management
```

### Models

**CertificationModel**
```vb
Public Property Id As String
Public Property Name As String
Public Property Organization As String
Public Property Year As Integer
Public Property Order As Integer
Public Property IsActive As Boolean
```

**PortfolioModel**
```vb
Public Property Id As String
Public Property Title As String
Public Property Description As String
Public Property Link As String
Public Property ImageUrl As String
Public Property Order As Integer
Public Property IsActive As Boolean
```

**AboutModel**
```vb
Public Property Id As String
Public Property Title As String
Public Property Description As String
Public Property SocialLink As String
```

**MessageModel**
```vb
Public Property Id As String
Public Property SenderName As String
Public Property SenderEmail As String
Public Property Subject As String
Public Property Message As String
Public Property CreatedAt As DateTime
Public Property IsRead As Boolean
```

## API Integration

The application connects to your API endpoints:
- `GET /api/certifications` - Fetch all certifications
- `POST /api/certifications` - Create new certification
- `PUT /api/certifications/{id}` - Update certification
- `DELETE /api/certifications/{id}` - Delete certification
- `GET /api/portfolios` - Fetch all portfolio projects
- `GET /api/about` - Get about section data
- `PUT /api/about/{id}` - Update about section
- `GET /api/messages` - Fetch contact messages

## Local Data Storage

The application stores data locally in your AppData folder:
- **Location**: `C:\Users\[YourUsername]\AppData\Roaming\AdminPanel\`
- **Files**:
  - `certifications.json` - Saved certifications
  - `about.json` - About section data
  - `portfolios.json` - Portfolio projects (optional)

This allows offline access and local backups of your data.

## Features

### Navigation
- **Dashboard**: Main statistics and overview
- **About**: Profile and bio management
- **Certification**: Certificate management
- **Portfolio**: Project management
- **Contact**: Message management

### Top Actions
- **🔄 Refresh**: Reload current page data
- **🔗 Go to Website**: Open your website in browser
- **🚪 Logout**: Exit the application

## How to Use

1. **Launch the Application**: Run the executable file
2. **Navigate**: Use the menu buttons to switch between sections
3. **Manage Data**: Add, edit, or delete information as needed
4. **Save Changes**: Click "Simpan" (Save) buttons to update
5. **Refresh**: Use the refresh button to sync with server
6. **View Website**: Click "Go to Website" to preview changes

## System Requirements

- **OS**: Windows 7 or higher
- **.NET Framework**: .NET 6.0 or higher
- **RAM**: 512 MB minimum
- **Internet Connection**: For API synchronization

## Installation

1. Download the application executable
2. Run the `.exe` file
3. Application will automatically create necessary folders
4. Start managing your website content!

## API Configuration

The base API URL is configured to:
```
https://www.samuelezranas.codes/api
```

To change the API endpoint, modify the `apiBaseUrl` variable in Form1.vb:
```vb
Private apiBaseUrl As String = "https://www.samuelezranas.codes/api"
```

## Data Synchronization

The application automatically:
- Fetches latest data from your server
- Stores data locally for offline access
- Syncs changes when saving
- Updates website content in real-time

## Error Handling

The application includes:
- Try-catch blocks for API errors
- Validation for input fields
- User-friendly error messages
- Debug logging for troubleshooting

## Security Notes

- Keep your admin credentials secure
- Don't share your API keys
- Store backups of important data
- Use HTTPS for all API communications

## Future Enhancements

Planned features for future versions:
- User authentication/login
- Image upload and management
- Advanced analytics dashboard
- Export/Import functionality
- Multi-language support
- Dark/Light theme toggle

## Support

For issues or feature requests, visit:
- Website: https://www.samuelezranas.codes/
- Admin Panel (Web): https://www.samuelezranas.codes/admin

## License

This application is part of your personal portfolio project.

## Developer

Created for managing **samuelezranas.codes** portfolio website.

---

**Version**: 1.0.0  
**Last Updated**: 2024  
**Status**: Production Ready
