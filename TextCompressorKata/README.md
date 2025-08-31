CodeX is working on a feature to compress text payloads before sending them across services, especially for bandwidth-constrained environments.

Build a simplified version of this system.

- Replace consecutive repeating characters with the character followed by the count.
- Only apply compression when it reduces the string size.
- Single characters shoul;d be left as-is (don't add "1").

Examples:

Compress("aaabbc") -> "a3b2c"
Compress("abcd") -> "abcd"
Decompress("a3b2c") -> "aaabbc"