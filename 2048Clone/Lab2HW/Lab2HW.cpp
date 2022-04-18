// Lab2HW.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "Lab2HW.h"

#include <stdio.h>
#include <map>

#define MAX_LOADSTRING 100

#define BOARD_SIZE 4
#define GAME_ACTIVE 0b00
#define GAME_INVACTIVE 0b10
#define GAME_WON 0b10
#define GAME_LOST 0b11 

#define MARGIN 10
#define SQUARE_SIZE 60
#define RADIUS 8

#define DIR_LEFT 1
#define DIR_UP 2
#define DIR_RIGHT 4
#define DIR_DOWN 8

#define ANIMATION_TIMER 0
#define ANIMATION_DELAY_MS 10


// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

HWND hParentWnd;
HWND hTwinWnd;


std::map<int, COLORREF> colorMap = {
    {0,     RGB(204, 192, 174) },
    {2,     RGB(238, 228, 198) },
    {4,     RGB(239, 225, 218) },
    {8,     RGB(243, 179, 124) },
    {16,    RGB(246, 153, 100)},
    {32,    RGB(246, 125, 98)},
    {64,    RGB(247, 93, 60)},
    {128,   RGB(237, 206, 116)},
    {256,   RGB(239, 204, 98)},
    {512,   RGB(243, 201, 85)},
    {1024,  RGB(238, 200, 72)},
    {2048,  RGB(239, 192, 47)}
};


// Forward declarations of functions included in this code module:
struct              Game;
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
double              ScaleAnimationCurve(double t);
void                ScaleRect(RECT* rc, double scale);
void                DrawSquare(HDC hdc, int i, int j, int value, double scale);
bool                TryShiftBoard(int board[BOARD_SIZE][BOARD_SIZE], int direction);
void                SpawnNewNumber(Game* game);
void                UpdateGameSquares(Game* game);
bool                AdvanceAnimation(double animationState[BOARD_SIZE][BOARD_SIZE]);
bool                CheckWinCondition(Game* game);
bool                CheckFailCondition(Game* game);
void                SaveGame(Game* game);
Game*               LoadGame();
void                PaintEndGameScreen(HDC hdc, HDC hdcMem, int state, RECT clientRc);
void                MirrorTwin(HWND hWnd, HWND hOtherWnd);
bool                IsNearCenter(HWND hWnd);
void                SetTranslucency(HWND hWnd, int translucency);

struct Game
{
    int target;
    int score;
    int state;
    int board[BOARD_SIZE][BOARD_SIZE];
    double animationState[BOARD_SIZE][BOARD_SIZE];
    
    Game()
    {
        target = 0;
        score = 0;
        state = GAME_ACTIVE;
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                board[i][j] = 0;
                animationState[i][j] = 1;
            }
        }
    }

    Game(int target) : target(target) 
    {
        for (int i = 0; i < BOARD_SIZE; i++)
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                board[i][j] = 0;
                animationState[i][j] = 1;
            }
        score = 0;
        state = GAME_ACTIVE;
        SpawnNewNumber(this);
    }

    Game(int target, int score, int state, int brd[BOARD_SIZE][BOARD_SIZE]) : target(target), score(score), state(state)
    {
        for (int i = 0; i < BOARD_SIZE; i++)
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                board[i][j] = brd[i][j];
                animationState[i][j] = 1;
            }    
    }

};

Game game;
int target;


int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_LAB2HW, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_LAB2HW));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ICON1));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = CreateSolidBrush(RGB(250, 247, 238));
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_LAB2HW);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_ICON1));

    return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   hParentWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   hTwinWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU,
       CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, hParentWnd, nullptr, hInstance, nullptr);


   if (!hParentWnd)
   {
      return FALSE;
   }

   ShowWindow(hParentWnd, nCmdShow);
   UpdateWindow(hParentWnd);

   ShowWindow(hTwinWnd, nCmdShow);
   UpdateWindow(hTwinWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE: Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    // hWnd = hParentWnd; // Perform everything on parent
    static int id;

    HWND parent = (hWnd);
    switch (message)
    {
    case WM_CREATE:
    {
        // Adjust window size and position in the middle to the left
        // 4x4 board 60px per square with 10px gap
        // 60px by (4 * 60px + 3 * 10px) = 235px scoreboard
        // 10px margins on the sides

        int clientWidth = 5 * 10 + 4 * 60;
        int clientHeight = 6 * 10 + 5 * 60;
        RECT rc = { 0, 0, clientWidth, clientHeight };
        AdjustWindowRect(&rc, GetWindowLong(hWnd, GWL_STYLE), TRUE);

        int centerX = GetSystemMetrics(SM_CXSCREEN) / 2;
        int centerY = GetSystemMetrics(SM_CYSCREEN) / 2;
        int windowWidth = rc.right - rc.left;
        int windowHeight = rc.bottom - rc.top;

        if (id++ == 0)
            MoveWindow(hWnd, centerX / 2 - windowWidth / 2, centerY - windowHeight / 2, windowWidth, windowHeight, TRUE);
        else if (id == 2) // Incremented twice
            MoveWindow(hWnd, 3 * centerX / 2 - windowWidth / 2, centerY - windowHeight / 2, windowWidth, windowHeight, TRUE);

        // SetTimers
        SetTimer(hWnd, ANIMATION_TIMER, ANIMATION_DELAY_MS, NULL);

        // Load / Create New Game
        Game* gameptr = LoadGame();
        if (gameptr == NULL)
            game = Game(2048);
        else
            game = *gameptr;

        // Check menu item
        if (game.target == 8) WndProc(hWnd, WM_COMMAND, IDM_8, 0);
        else if (game.target == 16) WndProc(hWnd, WM_COMMAND, IDM_16, 0);
        else if (game.target == 64) WndProc(hWnd, WM_COMMAND, IDM_64, 0);
        else if (game.target == 2048) WndProc(hWnd, WM_COMMAND, IDM_2048, 0);
        target = game.target;

    }
    break;
    case WM_TIMER:
    {
        switch (wParam)
        {
        case ANIMATION_TIMER:
            if (AdvanceAnimation(game.animationState)) 
                InvalidateRect(hWnd, NULL, FALSE);
            break;
        default:
            break;
        }
    }
    break;
    case WM_COMMAND:
        {
            int wmId = LOWORD(wParam);
            // Parse the menu selections:
            switch (wmId)
            {
            case IDM_NGAME:
                // DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
                game = Game(target);
                InvalidateRect(hParentWnd, NULL, FALSE);
                InvalidateRect(hTwinWnd, NULL, FALSE);
                break;
            case IDM_8:
            case IDM_16:
            case IDM_64:
            case IDM_2048:
                CheckMenuItem(GetMenu(hWnd), IDM_8, MF_UNCHECKED);
                CheckMenuItem(GetMenu(hWnd), IDM_16, MF_UNCHECKED);
                CheckMenuItem(GetMenu(hWnd), IDM_64, MF_UNCHECKED);
                CheckMenuItem(GetMenu(hWnd), IDM_2048, MF_UNCHECKED);
                CheckMenuItem(GetMenu(hWnd), wParam, MF_CHECKED);
                if (wParam == IDM_8) game.target = 8;
                else if (wParam == IDM_16) game.target = 16;
                else if (wParam == IDM_64) game.target = 64;
                else if (wParam == IDM_2048) game.target = 2048;
                target = game.target;
                break;
            default:
                return DefWindowProc(hWnd, message, wParam, lParam);
            }
        }
        break;
    case WM_PAINT:
        {
            PAINTSTRUCT ps;
            HDC hdc = BeginPaint(hWnd, &ps);
            // TODO: Add any drawing code that uses hdc here...

            // Create double buffering
            RECT windowRc;
            GetWindowRect(hWnd, &windowRc);
            RECT clientRc;
            GetClientRect(hWnd, &clientRc);

            HDC hdcMem = CreateCompatibleDC(hdc);
            HBITMAP hbmMem = CreateCompatibleBitmap(hdc, clientRc.right- clientRc.left, clientRc.bottom- clientRc.top);
            HBITMAP hbmOld = (HBITMAP)SelectObject(hdcMem, hbmMem);

            // Set brushes & pens;
            HBRUSH brush = CreateSolidBrush(RGB(204, 192, 174));
            HBRUSH bgBrush = CreateSolidBrush(RGB(250, 247, 238));
            HPEN nullPen = CreatePen(PS_NULL, 0, RGB(0, 0, 0));

            HBRUSH oldBrush = (HBRUSH)SelectObject(hdcMem, bgBrush);
            HPEN oldPen = (HPEN)SelectObject(hdcMem, nullPen);

            // Select font
            HFONT hFont = (HFONT)GetStockObject(DEFAULT_GUI_FONT);
            LOGFONT logfont;
            GetObject(hFont, sizeof(LOGFONT), &logfont);

            logfont.lfHeight = 25;
            logfont.lfWeight = FW_SEMIBOLD;

            HFONT hNewFont = CreateFontIndirect(&logfont);
            HFONT hOldFont = (HFONT)SelectObject(hdcMem, hNewFont);

            // DrawBackground
            // Rectangle(hdcMem, clientRc.left, clientRc.top, clientRc.right, clientRc.bottom);
            FillRect(hdcMem, &clientRc, bgBrush);

            // Draw scoreboard
            SelectObject(hdcMem, brush);
            int sbWidth = SQUARE_SIZE * BOARD_SIZE + (BOARD_SIZE - 1) * MARGIN;
            RECT sbRc = { MARGIN, MARGIN, MARGIN + sbWidth, MARGIN + SQUARE_SIZE };
            RoundRect(hdcMem, sbRc.left, sbRc.top, sbRc.right, sbRc.bottom, RADIUS * 2, RADIUS * 2);

            SetBkMode(hdcMem, TRANSPARENT);
            SetTextColor(hdcMem, RGB(255, 255, 255));

            wchar_t scoreText[11];
            int len = wsprintfW(scoreText, L"%d", game.score);
            DrawText(hdcMem, (LPCWSTR)scoreText, len, &sbRc, DT_CENTER | DT_VCENTER | DT_SINGLELINE);

            // Draw squares
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    DrawSquare(hdcMem, i, j, game.board[i][j], ScaleAnimationCurve(game.animationState[i][j]));
                }
            }

            
            BitBlt(hdc, 0, 0, windowRc.right - windowRc.left, windowRc.bottom - windowRc.top, hdcMem, 0, 0, SRCCOPY);

            if ((game.state & GAME_INVACTIVE) != 0)
                PaintEndGameScreen(hdc, hdcMem, game.state, clientRc);


            // Cleanup
            SelectObject(hdcMem, oldBrush);
            SelectObject(hdcMem, oldPen);
            DeleteObject(brush);
            DeleteObject(nullPen);
            DeleteObject(bgBrush);

            SelectObject(hdcMem, hOldFont);
            DeleteObject(hNewFont);

            SelectObject(hdcMem, hbmOld);
            DeleteObject(hbmMem);
            DeleteDC(hdcMem);

            EndPaint(hWnd, &ps);
        }
        break;
    case WM_KEYDOWN:
    {
        if (id == 0) int a = 0;
        if (game.state & GAME_INVACTIVE)
            return 0;

        int direction = 0;
        switch (wParam)
        {
        case ('W'):
            direction = DIR_UP;
            break;
        case ('A'):
            direction = DIR_LEFT;
            break;
        case ('S'):
            direction = DIR_DOWN;
            break;
        case ('D'):
            direction = DIR_RIGHT;
            break;
        default:
            return 0 ;
        }
        bool moveSuccessful = false;
        moveSuccessful = TryShiftBoard(game.board, direction);
        UpdateGameSquares(&game);
        if (moveSuccessful)
            SpawnNewNumber(&game);
        if (CheckWinCondition(&game))
        {
            game.state = GAME_WON;
        }
        else if (CheckFailCondition(&game))
        {
            game.state = GAME_LOST;
        }
        InvalidateRect(hParentWnd, NULL, FALSE);
        InvalidateRect(hTwinWnd, NULL, FALSE);

    }
    break;
    case WM_MOVING:
    {
        HWND hOtherWnd = (hWnd == hParentWnd ? hTwinWnd : hParentWnd);
        MirrorTwin(hWnd, hOtherWnd);
        
        // Only parent window will be made translucent
        // if (hWnd == hTwinWnd) break;

        if (IsNearCenter(hWnd))
            SetTranslucency(hTwinWnd, 50);
        else
            SetTranslucency(hTwinWnd, 100);


    }
    break;
    case WM_DESTROY:
        SaveGame(&game);
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}


double ScaleAnimationCurve(double t)
{
    // Assumes t is in [0, 1]
    // Custom animation curve that scales from 1 to 1.2 and then back to 1
    return -t * (t - 1) * 0.7 + 1;
    // return t / 2 + 0.5;
}

void ScaleRect(RECT* rc, double scale)
{
    scale = scale - 1;
    double width = (double)rc->right - (double)rc->left;
    double height = (double)rc->bottom - (double)rc->top;
    rc->left = rc->left - width * scale / 2;
    rc->right = rc->right + width * scale / 2;
    rc->top = rc->top - height * scale / 2;
    rc->bottom = rc->bottom + height * scale / 2;
}

void DrawSquare(HDC hdc, int i, int j, int value, double scale)
{
    // Select brush
    HBRUSH brush = CreateSolidBrush(colorMap[value]);
    HBRUSH oldBrush = (HBRUSH)SelectObject(hdc, brush);

    int left, top;
    left = MARGIN * (j + 1) + SQUARE_SIZE * j;
    top = MARGIN * (i + 2) + SQUARE_SIZE * (i + 1);
    RECT square = { left, top, left + SQUARE_SIZE, top + SQUARE_SIZE };
    ScaleRect(&square, scale);
    RoundRect(hdc, square.left, square.top, square.right, square.bottom, RADIUS * 2, RADIUS * 2);

    // SetBkMode(hdc, TRANSPARENT);
    SetTextColor(hdc, RGB(255, 255, 255));

    wchar_t valueText[5];
    int len = value != 0 ? wsprintfW(valueText, L"%d", value) : wsprintfW(valueText, L"");
    DrawText(hdc, (LPCWSTR)valueText, len, &square, DT_CENTER | DT_VCENTER | DT_SINGLELINE );

    // Clean up

    SelectObject(hdc, oldBrush);
    DeleteObject(brush);

}

bool TryShiftSquareLeft(int row, int col, int board[BOARD_SIZE][BOARD_SIZE])
{
    if (col == 0) return false;

    int k = col;
    while (true) 
    { 
        if (--k == -1) break;
        if (board[row][k] != 0) break;
    }
    if (k == -1) 
    { 
        board[row][0] = board[row][col]; 
        board[row][col] = 0; 
        return true; 
    }
    else if (board[row][k] == board[row][col]) 
    { 
        board[row][k] = -2 * board[row][col]; 
        board[row][col] = 0;
        return true;
    }
    else if (k != col - 1) 
    { 
        board[row][k + 1] = board[row][col]; 
        board[row][col] = 0; 
        return true;
    }
    return false;
}

bool TryShiftSquareUp(int row, int col, int board[BOARD_SIZE][BOARD_SIZE])
{
    if (row == 0) return false;

    int k = row;
    while (true)
    {
        if (--k == -1) break;
        if (board[k][col] != 0) break;
    }
    if (k == -1)
    {
        board[0][col] = board[row][col];
        board[row][col] = 0;
        return true;
    }
    else if (board[k][col] == board[row][col])
    {
        board[k][col] = -2 * board[row][col];
        board[row][col] = 0;
        return true;
    }
    else if (k != row - 1)
    {
        board[k + 1][col] = board[row][col];
        board[row][col] = 0;
        return true;
    }
    return false;
}

bool TryShiftSquareRight(int row, int col, int board[BOARD_SIZE][BOARD_SIZE])
{
    if (col == BOARD_SIZE - 1) return false;

    int k = col;
    while (true)
    {
        if (++k == BOARD_SIZE) break;
        if (board[row][k] != 0) break;
    }
    if (k == BOARD_SIZE)
    {
        board[row][BOARD_SIZE - 1] = board[row][col];
        board[row][col] = 0;
        return true;
    }
    else if (board[row][k] == board[row][col])
    {
        board[row][k] = -2 * board[row][col];
        board[row][col] = 0;
        return true;
    }
    else if (k != col + 1)
    {
        board[row][k - 1] = board[row][col];
        board[row][col] = 0;
        return true;
    }
    return false;
}

bool TryShiftSquareDown(int row, int col, int board[BOARD_SIZE][BOARD_SIZE])
{
    if (row == BOARD_SIZE - 1) return false;

    int k = row;
    while (true)
    {
        if (++k == BOARD_SIZE) break;
        if (board[k][col] != 0) break;
    }
    if (k == BOARD_SIZE)
    {
        board[BOARD_SIZE - 1][col] = board[row][col];
        board[row][col] = 0;
        return true;
    }
    else if (board[k][col] == board[row][col])
    {
        board[k][col] = -2 * board[row][col];
        board[row][col] = 0;
        return true;
    }
    else if (k != row + 1)
    {
        board[k - 1][col] = board[row][col];
        board[row][col] = 0;
        return true;
    }
    return false;
}

bool TryShiftBoard(int board[BOARD_SIZE][BOARD_SIZE], int direction)
{
    bool anyMove = false;
    bool (*shiftFunc)(int, int, int[BOARD_SIZE][BOARD_SIZE]) = &TryShiftSquareLeft;
    if (direction == DIR_LEFT) shiftFunc = &TryShiftSquareLeft;
    else if (direction == DIR_UP) shiftFunc = &TryShiftSquareUp;
    else if (direction == DIR_RIGHT) shiftFunc = &TryShiftSquareRight;
    else if (direction == DIR_DOWN) shiftFunc = &TryShiftSquareDown;

    int startRow = 0, startCol = 0, rowOffset = 1, colOffset = 1;
    if (direction == DIR_RIGHT)     { startCol = BOARD_SIZE - 1; colOffset = -1; }
    else if (direction == DIR_DOWN) { startRow = BOARD_SIZE - 1; rowOffset = -1; }

    for (int row = startRow; 0 <= row && row < BOARD_SIZE; row += rowOffset)
    {
        for (int col = startCol; 0 <= col && col < BOARD_SIZE; col += colOffset)
        {
            if (board[row][col] == 0) continue;
            anyMove = shiftFunc(row, col, board) || anyMove;
        }
    }
    /*for (int i = 0; i < BOARD_SIZE; i++)
        for (int j = 0; j < BOARD_SIZE; j++)
            board[i][j] = abs(board[i][j]);*/

    return anyMove;
}

void SpawnNewNumber(Game* game)
{
    // Check if any square empty
    bool anyEmpty = false;
    for (int i = 0; i < BOARD_SIZE; i++)
        for (int j = 0; j < BOARD_SIZE; j++)
            if (game->board[i][j] == 0) { anyEmpty = true; break; }
    if (anyEmpty == false) return;

    // Naive but fast approach
    do {
        int i = rand() % 4;
        int j = rand() % 4;
        if (game->board[i][j] == 0)
        {
            game->board[i][j] = 2;
            game->animationState[i][j] = 0;
            break;
        }
    } while (true);
    return;
}

void UpdateGameSquares(Game* game)
{
    for (int i = 0; i < BOARD_SIZE; i++)
    {
        for (int j = 0; j < BOARD_SIZE; j++)
        {
            if (game->board[i][j] < 0) 
            {
                game->board[i][j] *= -1;
                game->score += game->board[i][j];
                game->animationState[i][j] = 0;
            }
        }
    }
}

bool AdvanceAnimation(double animationState[BOARD_SIZE][BOARD_SIZE])
{
    double offset = 0.1;
    bool anythingAnimated = false;
    for (int i = 0; i < BOARD_SIZE; i++)
    {
        for (int j = 0; j < BOARD_SIZE; j++)
        {
            if (animationState[i][j] < 1)
            {
                animationState[i][j] = min(animationState[i][j] + offset, 1.0);
                anythingAnimated = true;
            }
        }
    }
    return anythingAnimated;
}

bool CheckWinCondition(Game* game)
{
    for (int i = 0; i < BOARD_SIZE; i++)
        for (int j = 0; j < BOARD_SIZE; j++)
            if (game->board[i][j] >= game->target) return true;
    return false;
}

bool CheckFailCondition(Game* game)
{
    auto hasSameNeighbours = [=](int i, int j)
    {

        if (i > 0 && game->board[i - 1][j] == game->board[i][j]) return true;
        if (j > 0 && game->board[i][j - 1] == game->board[i][j]) return true;
        if (i < BOARD_SIZE - 1 && game->board[i + 1][j] == game->board[i][j]) return true;
        if (j < BOARD_SIZE - 1 && game->board[i][j + 1] == game->board[i][j]) return true;
        return false;
    };
    // No squares left empty
    // No two adjecten same-valued squares
    for (int i = 0; i < BOARD_SIZE; i++)
    {
        for (int j = 0; j < BOARD_SIZE; j++)
        {
            if (game->board[i][j] == 0) return false;
            if (hasSameNeighbours(i, j)) return false;
        }
    }
    return true;
}

void SaveGame(Game* game)
{
    char buffer[65];
    // Save target
    sprintf_s(buffer, "%d", game->target);
    WritePrivateProfileStringA("2048app", "target", buffer, "./2048save.sav");

    // Save score
    sprintf_s(buffer, "%d", game->score);
    WritePrivateProfileStringA("2048app", "score", buffer, "./2048save.sav");

    // Save state
    sprintf_s(buffer, "%d", game->state);
    WritePrivateProfileStringA("2048app", "state", buffer, "./2048save.sav");

    // Save squares
    buffer[0] = '\0';
    for (int i = 0; i < BOARD_SIZE; i++)
    {
        for (int j = 0; j < BOARD_SIZE; j++)
        {
            sprintf_s(buffer, "%s%04d", buffer, game->board[i][j]);
        }
    }
    WritePrivateProfileStringA("2048app", "squares", buffer, "./2048save.sav");
}

Game* LoadGame()
{
    char buffer[65];
    char chunk[5];

    // Read target
    GetPrivateProfileStringA("2048app", "target", NULL, buffer, 65, "./2048save.sav");
    if (buffer[0] == NULL)
        return NULL;
    strncpy_s(chunk, buffer, 4);
    int target = std::atoi(chunk);

    // Read score
    GetPrivateProfileStringA("2048app", "score", NULL, buffer, 65, "./2048save.sav");
    strncpy_s(chunk, buffer, 4);
    int score = std::atoi(chunk);

    // Read state
    GetPrivateProfileStringA("2048app", "state", NULL, buffer, 65, "./2048save.sav");
    strncpy_s(chunk, buffer, 4);
    int state = std::atoi(chunk);


    // Read state
    GetPrivateProfileStringA("2048app", "squares", NULL, buffer, 65, "./2048save.sav");
    int val, i, j;
    int board[BOARD_SIZE][BOARD_SIZE];

    for (int k = 0; k < BOARD_SIZE * BOARD_SIZE * 4; k+=4)
    {
        strncpy_s(chunk, buffer + k , 4);
        val = std::atoi(chunk);
        i = k / 16;
        j = (k / 4) % 4;
        board[i][j] = val;
    }
    Game game(target, score, state, board);
    return &game;
}

void PaintEndGameScreen(HDC hdc, HDC hdcMem, int state, RECT clientRc)
{
    // Paint translucent overlay
    HBRUSH brush = state == GAME_WON ? CreateSolidBrush(RGB(100, 200, 100)) : CreateSolidBrush(RGB(200, 100, 100));
    FillRect(hdcMem, &clientRc, brush);
    DeleteObject(brush);

    BLENDFUNCTION bf;
    bf.BlendOp = AC_SRC_OVER;
    bf.BlendFlags = 0;
    bf.SourceConstantAlpha = 136;
    bf.AlphaFormat = 0;
    AlphaBlend(hdc, clientRc.left, clientRc.top, clientRc.right - clientRc.left, clientRc.bottom - clientRc.top,
        hdcMem, clientRc.left, clientRc.top, clientRc.right - clientRc.left, clientRc.bottom - clientRc.top, bf);

    // Write text
    HFONT hFont = (HFONT)GetStockObject(DEFAULT_GUI_FONT);
    LOGFONT logfont;
    GetObject(hFont, sizeof(LOGFONT), &logfont);

    logfont.lfHeight = 40;
    logfont.lfWeight = FW_SEMIBOLD;

    HFONT hNewFont = CreateFontIndirect(&logfont);
    HFONT hOldFont = (HFONT)SelectObject(hdc, hNewFont);

    SetBkMode(hdc, TRANSPARENT);
    SetTextColor(hdc, RGB(255, 255, 255));

    LPCWSTR message = (state == GAME_WON ? L"WIN!" : L"GAME OVER!");
    int len = state == GAME_WON ? 4 : 10;
    DrawText(hdc, message, len, &clientRc, DT_CENTER | DT_VCENTER | DT_SINGLELINE);

    
}

void MirrorTwin(HWND hWnd, HWND hOtherWnd)
{
    int centerX = GetSystemMetrics(SM_CXSCREEN) / 2;
    int centerY = GetSystemMetrics(SM_CYSCREEN) / 2;

    RECT rcg;
    GetWindowRect(hWnd, &rcg);

    int width = rcg.right - rcg.left;
    int height = rcg.bottom - rcg.top;
    int midpointX = rcg.left + width / 2;
    int midpointY = rcg.top + height / 2;
    MoveWindow(hOtherWnd, centerX + (centerX - midpointX) - width / 2, centerY + (centerY - midpointY) - height / 2, width, height, FALSE);
}

bool IsNearCenter(HWND hWnd)
{
    int centerX = GetSystemMetrics(SM_CXSCREEN) / 2;
    int centerY = GetSystemMetrics(SM_CYSCREEN) / 2;

    RECT rc;
    GetWindowRect(hWnd, &rc);
    int width = rc.right - rc.left;
    int height = rc.bottom - rc.top;
    int midpointX = width / 2 + rc.left;
    int midpointY = height / 2 + rc.top;
    
    return abs(midpointX - centerX) < width / 2 && abs(midpointY - centerY) < height / 2;
}

void SetTranslucency(HWND hWnd, int translucency)
{
    SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED);
    SetLayeredWindowAttributes(hWnd, 0, (255 * translucency) / 100, LWA_ALPHA);
}