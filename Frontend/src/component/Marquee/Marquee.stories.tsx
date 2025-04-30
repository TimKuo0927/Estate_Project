// Header.stories.tsx
import type { Meta, StoryObj } from '@storybook/react';
import Marquee from "./Marquee";

const meta: Meta<typeof Marquee> = {
  title: 'Component/Marquee',
  component: Marquee,
  tags: ['autodocs'], // Optional: enables Storybook's auto docs
};

export default meta;
type Story = StoryObj<typeof Marquee>;

export const Default: Story = {
  render: () => {
    let imageList:string[] = [
        "https://images.unsplash.com/photo-1744600511717-54db78d29098?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        "https://images.unsplash.com/photo-1745750747233-c09276a878b3?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
        "https://images.unsplash.com/photo-1745761412274-5303bc3f2e45?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
    ]
    return(
        <Marquee imageList={imageList} />
    )
  },
};
