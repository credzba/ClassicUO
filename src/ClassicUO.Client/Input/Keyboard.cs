#region license

// Copyright (c) 2024, andreakarasho
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 1. Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// 2. Redistributions in binary form must reproduce the above copyright
//    notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 3. All advertising materials mentioning features or use of this software
//    must display the following acknowledgement:
//    This product includes software developed by andreakarasho - https://github.com/andreakarasho
// 4. Neither the name of the copyright holder nor the
//    names of its contributors may be used to endorse or promote products
//    derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS ''AS IS'' AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using SDL2;
using System;

namespace ClassicUO.Input
{
    internal static class Keyboard
    {
        private static SDL.SDL_Keycode _code;
        public static SDL.SDL_Keymod IgnoreKeyMod { get; } = SDL.SDL_Keymod.KMOD_CAPS | SDL.SDL_Keymod.KMOD_NUM | SDL.SDL_Keymod.KMOD_MODE | SDL.SDL_Keymod.KMOD_RESERVED;
        public static bool Alt { get; private set; }
        public static bool Shift { get; private set; }
        public static bool Ctrl { get; private set; }

        public static void Initialize()
        {
            SDL.SDL_SetHint(SDL.SDL_HINT_NO_SIGNAL_HANDLERS, "1");
            SDL.SDL_EventState(SDL.SDL_EventType.SDL_SYSWMEVENT, SDL.SDL_IGNORE);
            SDL.SDL_EventState(SDL.SDL_EventType.SDL_TEXTINPUT, SDL.SDL_IGNORE);
            SDL.SDL_EventState(SDL.SDL_EventType.SDL_TEXTEDITING, SDL.SDL_IGNORE);
        }

        public static void OnKeyUp(SDL.SDL_KeyboardEvent e)
        {
            ProcessKeyEvent(e, isKeyDown: false);
        }

        public static void OnKeyDown(SDL.SDL_KeyboardEvent e)
        {
            ProcessKeyEvent(e, isKeyDown: true);
        }

        private static void ProcessKeyEvent(SDL.SDL_KeyboardEvent e, bool isKeyDown)
        {
            SDL.SDL_Keymod mod = e.keysym.mod & ~IgnoreKeyMod;

            Shift = (mod & SDL.SDL_Keymod.KMOD_SHIFT) != SDL.SDL_Keymod.KMOD_NONE;
            Alt = (mod & SDL.SDL_Keymod.KMOD_ALT) != SDL.SDL_Keymod.KMOD_NONE;
            Ctrl = (mod & SDL.SDL_Keymod.KMOD_CTRL) != SDL.SDL_Keymod.KMOD_NONE;

            if (e.keysym.sym != SDL.SDL_Keycode.SDLK_UNKNOWN)
            {
                _code = e.keysym.sym;
            }

            if (isKeyDown)
            {
                Console.WriteLine($"Key Down: {_code}, Modifiers: Shift={Shift}, Alt={Alt}, Ctrl={Ctrl}");
                // Add your key down handling logic here
            }
            else
            {
                Console.WriteLine($"Key Up: {_code}, Modifiers: Shift={Shift}, Alt={Alt}, Ctrl={Ctrl}");
                // Add your key up handling logic here
            }
        }

        public static void Update()
        {
            SDL.SDL_Event sdlEvent;
            while (SDL.SDL_PollEvent(out sdlEvent) != 0)
            {
                switch (sdlEvent.type)
                {
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        OnKeyDown(sdlEvent.key);
                        // Prevent further processing of this key event
                        sdlEvent.key.keysym.sym = SDL.SDL_Keycode.SDLK_UNKNOWN;
                        SDL.SDL_PushEvent(ref sdlEvent);
                        break;
                    case SDL.SDL_EventType.SDL_KEYUP:
                        OnKeyUp(sdlEvent.key);
                        // Prevent further processing of this key event
                        sdlEvent.key.keysym.sym = SDL.SDL_Keycode.SDLK_UNKNOWN;
                        SDL.SDL_PushEvent(ref sdlEvent);
                        break;
                        // Handle other event types as needed
                }
            }
        }
    }
}