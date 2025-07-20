# AutoFix Project Documentation

## Overview
AutoFix is an automated system that detects, analyzes, and fixes C# code errors using AI-powered solutions. The system processes error logs, generates fixes using Together AI's LLM, and automatically creates pull requests with the fixes.

## Architecture

### 1. Project Structure
```
FullAutoFixProject/
├── CourseApp/               # Sample C# application
│   ├── CourseService.cs     # Contains sample bugs
│   ├── CourseController.cs  # Contains sample bugs
│   └── logs/
│       └── errors.log       # Error log file
├── create_branch.py         # Git branch creation
├── analyze_and_fix_together.py  # Error analysis
├── apply_fix.py            # Patch application
└── create_pr.py            # PR creation
```

### 2. Components & Flow

#### 2.1 Error Generation (CourseApp)
- Sample C# application with intentional bugs:
  - DivideByZeroException
  - NullReferenceException
  - InvalidOperationException
  - IndexOutOfRangeException

#### 2.2 Error Processing Pipeline

1. **Branch Creation** (`create_branch.py`)
   - Creates a new Git branch with format `auto-fix-{uuid}`
   - Ensures clean state by pulling latest master
   - Stores branch name for later use

2. **Error Analysis** (`analyze_and_fix_together.py`)
   - Reads error logs from `logs/errors.log`
   - Parses log entries using regex
   - Extracts:
     - File name
     - Line number
     - Exception type
     - Error message
   - Deduplicates errors using unique keys
   - Uses Together AI's Mixtral-8x7B model for fix generation
   - Maintains context window of 10 lines around error

3. **Fix Application** (`apply_fix.py`)
   - Takes AI-generated fixes
   - Creates backup of original files
   - Applies patches to source files
   - Validates changes

### 3. Key Features

#### 3.1 Error Log Format
```
[ERROR] [timestamp] [filename:line] ExceptionType: Message
```

#### 3.2 Together AI Integration
- Uses Mixtral-8x7B-Instruct model
- Prompt structure:
  ```
  You're a senior C# engineer. A file `{file_path}` has an error:
  Exception: {exception}
  Message: {message}
  Code context: {context}
  ```

#### 3.3 Safety Features
- File backups before changes
- Deduplication of similar errors
- Context-aware fixes
- Branch-based changes

### 4. Configuration
Required environment variables:
- `TOGETHER_API_KEY`: Together AI API key
- `GITHUB_TOKEN`: GitHub access token

### 5. Usage

```bash
# Set up environment
export TOGETHER_API_KEY=your_key
export GITHUB_TOKEN=your_token

# Run pipeline
python create_branch.py
python analyze_and_fix_together.py
python apply_fix.py
python create_pr.py
```

### 6. Error Types Handled
1. Null Reference Checks
2. Array Bounds Validation
3. Division by Zero Prevention
4. Collection Empty Checks

### 7. Future Improvements
1. Add test validation before PR
2. Implement fix confidence scoring
3. Add manual review option
4. Expand supported error types
5. Add rollback mechanism
